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

    private int activeLineIndex;
    private bool conversationStarted = false;


    private int activeClipIndex;

   // private AudioSource audioSource;




    public void ChangeConversation(Conversation nextConversation)
    {
        conversationStarted = false;
        conversation = nextConversation;
        AdvanceLine();
    }


    private void Start()
    {
        speakerUi  = speaker.GetComponent<SpeakerUI>(); //speakerUi.GetComponent<SpeakerUI>();
        playerUi = player.GetComponent<SpeakerUI>(); //playerUi.GetComponent<SpeakerUI>();



    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
            AdvanceLine();
        else if (Input.GetKeyDown("x"))
            EndConversation();
    }
   
    private void EndConversation() {
        conversation = null;
        conversationStarted = false;
        speakerUi.Hide();
        playerUi.Hide();
    }

    private void Initialize() {
        conversationStarted = true;
        activeLineIndex = 0;
        activeClipIndex = 0;


        speakerUi.Speaker = conversation.speaker;
        playerUi.Speaker = conversation.player;
    }

    private void AdvanceLine() {
        if (conversation == null) return;
        if (!conversationStarted) Initialize();

        if (activeLineIndex < conversation.lines.Length)
        {
            DisplayLine();
            activeLineIndex += 1;
            PlayClip();
            activeClipIndex += 1;




        }

        else
        {
            AdvanceConversation();
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
        // AudioClip voiceClip = conversation.voiceclips[activeClipIndex];

        AudioSource audio = GetComponent<AudioSource>();

        audio.clip = conversation.voiceclips[activeClipIndex];
        audio.Play();



    }



    private void AdvanceConversation() {
      
        if (conversation.question != null)
            questionEvent.Invoke(conversation.question);
        else if (conversation.nextConversation != null)
            ChangeConversation(conversation.nextConversation);
        else
            EndConversation();
    }

    private void SetDialog(
        SpeakerUI activeSpeakerUI,
        SpeakerUI inactiveSpeakerUI,
        string text
    ) {
        activeSpeakerUI.Show();
        inactiveSpeakerUI.Hide();

        activeSpeakerUI.Dialouge = text;
       // StopAllCoroutines();
        //StartCoroutine(EffectTypewriter(text, activeSpeakerUI));
    }
    /*
    private IEnumerator EffectTypewriter(string text, SpeakerUI controller) {
        foreach(char character in text.ToCharArray()) 
        {
            controller.Dialouge += character;
            // yield return new  WaitForSeconds(0.1f);
            yield return null;
       }
    }
     */
}