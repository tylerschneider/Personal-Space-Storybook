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

    private SpeakerUI speakerUi; 
    private SpeakerUI playerUi;

    public int activeLineIndex;
    public int activeClipIndex;

    public bool conversationStarted = false;
    public bool conversationEnded = false;


    private void Start()
    {
        speakerUi = speaker.GetComponent<SpeakerUI>(); //speakerUi.GetComponent<SpeakerUI>();
        playerUi = player.GetComponent<SpeakerUI>(); //playerUi.GetComponent<SpeakerUI>();
    }

    public void ChangeConversation(Conversation nextConversation)
    {
        conversationStarted = false;
        conversation = nextConversation;
        AdvanceLine();
    }

    /*private void Update()
    {
        if (Input.GetKeyDown("space"))
            AdvanceLine();
        else if (Input.GetKeyDown("x"))
            EndConversation();
    }*/
   
    private void EndConversation() {
        conversationStarted = false;
        conversationEnded = true;
        activeClipIndex = 0;
        activeLineIndex = 0;
        speakerUi.Hide();
        playerUi.Hide();
    }

    public void Initialize()
    {
        conversationStarted = true;
        activeLineIndex = 0;
        activeClipIndex = 0;

        speakerUi.Speaker = conversation.speaker;
        playerUi.Speaker = conversation.player;
    }

    public void AdvanceLine() {
        if (activeLineIndex < conversation.lines.Length)
        {
            DisplayLine();
            activeLineIndex += 1;
            PlayClip();
            activeClipIndex += 1;

            if(activeLineIndex >= conversation.lines.Length)
            {
                EndConversation();
            }
        }
    }

    private void DisplayLine() {
        Line line = conversation.lines[activeLineIndex];
        Character character = line.character;

        if (speakerUi.SpeakerIs(character))
        {
            SetDialog(speakerUi, playerUi, line.text);
        }
        else {
            SetDialog(playerUi, speakerUi, line.text);
        }

        
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

    private void SetDialog(SpeakerUI activeSpeakerUI, SpeakerUI inactiveSpeakerUI, string text)
    {
        activeSpeakerUI.Show();
        inactiveSpeakerUI.Hide();

        activeSpeakerUI.Dialouge = text;
    }
}