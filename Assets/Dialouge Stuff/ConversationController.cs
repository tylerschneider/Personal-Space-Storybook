using UnityEngine;
using UnityEditor;
using UnityEngine.Events;
using System.Collections;

[System.Serializable]
public class QuestionEvent : UnityEvent<Question> {}

public class ConversationController : MonoBehaviour
{
    public Conversation conversation;
    public QuestionEvent questionEvent;

    public GameObject speaker;
    public GameObject player;

    public SpeakerUI speakerUi; 
    private SpeakerUI playerUi;

    public int activeLineIndex;
    public int activeClipIndex;

    public bool conversationStarted = false;
    public bool conversationEnded = false;


    private void Start()
    {
        speakerUi = speaker.GetComponent<SpeakerUI>();
        playerUi = player.GetComponent<SpeakerUI>();
    }
   
    public void ChangeConversation(Conversation nextConversation)
    {
        conversationStarted = false;
        conversation = nextConversation;
        AdvanceLine();
    }
   
    private void EndConversation() {
        conversationStarted = false;
        conversationEnded = true;
        activeClipIndex = 0;
        activeLineIndex = 0;
        //speakerUi.Hide();
    }

    public void Initialize()
    {
        conversationEnded = false;
        activeLineIndex = 0;
        activeClipIndex = 0;
    }

    public void AdvanceLine() {
        if (activeLineIndex < conversation.lines.Length)
        {
            DisplayLine();
            activeLineIndex++;
            PlayClip();
            activeClipIndex++;

            if(activeLineIndex == conversation.lines.Length)
            {
                EndConversation();
            }
        }
    }

    private void DisplayLine() {
        Line line = conversation.lines[activeLineIndex];
        Character character = line.character;

        SetDialog(speakerUi, playerUi, line.text, character);
    }

    private void PlayClip()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.clip = conversation.voiceclips[activeClipIndex];
        audio.Play();
    }

    public void AdvanceConversation() {
      
        if (conversation.question != null)
            questionEvent.Invoke(conversation.question);
        else if (conversation.nextConversation != null)
            ChangeConversation(conversation.nextConversation);
        else
            EndConversation();
    }

    private void SetDialog(SpeakerUI activeSpeakerUI, SpeakerUI inactiveSpeakerUI, string text, Character character)
    {
        activeSpeakerUI.Show();
        inactiveSpeakerUI.Hide();

        activeSpeakerUI.Dialouge = text;
        activeSpeakerUI.fullName.text = character.fullName;
    }
}