using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteMenuManager : MonoBehaviour
{
    public LessonData data;
    public Text title;
    public Text date;
    public GameObject readMode;
    public GameObject editMode;
    public Text readModeText;
    public InputField editModeText; 

    private void OnEnable()
    {
        title.text = data.lesson;
        date.text = data.date.ToString("MM/dd/yy") + " Note";
        readModeText.text = data.note;
        editModeText.text = data.note;
    }

    public void SwitchMode(bool edit)
    {
        readMode.SetActive(!edit);
        editMode.SetActive(edit);
    }

    public void SubmitEdit()
    {
        LessonManager.Instance.UpdateLessonNote(editModeText.text, data.guid);
        readModeText.text = editModeText.text;
    }

    public void CancelEdit()
    {
        editModeText.text = readModeText.text;
    }

    private void OnDisable()
    {
        title.text = "";
        date.text = "";
        readModeText.text = "";
        editModeText.text = "";
        data = null;
    }
}
