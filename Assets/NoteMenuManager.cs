using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteMenuManager : MonoBehaviour
{
    //the clicked lesson's data
    public LessonData data;
    //holds the title of the selected lesson's note menu
    public Text title;
    //holds the label which displays the selected lesson's date
    public Text date;
    //read menu gameobject
    public GameObject readMode;
    //edit menu gameobject
    public GameObject editMode;
    //label that displays the note
    public Text readModeText;
    //input field where notes are edited
    public InputField editModeText; 

    private void OnEnable()
    {
        //display the given data's appropriate text
        title.text = data.lesson;
        date.text = data.date.ToString("MM/dd/yy") + " Note";
        readModeText.text = data.note;
        editModeText.text = data.note;
    }

    public void SwitchMode(bool edit)
    {
        //disables/enables the note edit menu
        readMode.SetActive(!edit);
        editMode.SetActive(edit);
    }

    public void SubmitEdit()
    {
        //update the saved note data using the user's note input
        LessonManager.Instance.UpdateLessonNote(editModeText.text, data.guid);
        readModeText.text = editModeText.text;
    }

    public void CancelEdit()
    {
        //undoes any edits made to the input box when pressing the back button
        editModeText.text = readModeText.text;
    }

    private void OnDisable()
    {
        //clear the data when the note menu is closed
        title.text = "";
        date.text = "";
        readModeText.text = "";
        editModeText.text = "";
        data = null;
    }
}
