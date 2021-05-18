using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialougeDisplay : MonoBehaviour
{

    public Conversation conversation;

    public GameObject speaker;
    public GameObject player;

    private SpeakerUI speakerUi;
    private SpeakerUI playerUi;

    private int activeLineIndex = 0;
    private int activeClipIndex = 0;


   // public Text name


    void Start()
    {

        speakerUi = speaker.GetComponent<SpeakerUI>();
        playerUi = player.GetComponent<SpeakerUI>();

        speakerUi.Speaker = conversation.speaker;
        playerUi.Speaker = conversation.player;

        
    }



    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            AdvanceConversation();
        }
    }

    void AdvanceConversation()
    {
        if (activeLineIndex < conversation.lines.Length)
        {
            DisplayLine();
            activeLineIndex += 1;

            PlayClip();
            activeClipIndex += 1;

        }
        else
        {
            playerUi.Hide();
            speakerUi.Hide();
            activeLineIndex = 0;
        }


    }


    void DisplayLine()
    {
        Line line = conversation.lines[activeLineIndex];
        Character character = line.character;

        


        Debug.Log(conversation);

        if (speakerUi.SpeakerIs(character))
        {
            SetDialouge(speakerUi, playerUi, line.text);
        }
        else
        {
            SetDialouge(playerUi, speakerUi, line.text);
        }

    }



    void PlayClip()
    {



    }





    void SetDialouge( 
        SpeakerUI activeSpeakerUi, 
        SpeakerUI inactiveSpeakerUi,
        string text
        ){

        activeSpeakerUi.Dialouge = text;
        activeSpeakerUi.Show();
        inactiveSpeakerUi.Hide();
    
    }

}
