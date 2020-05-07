using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HistoryButton : MonoBehaviour
{
    public LessonData data;
    public void OnClick()
    {
        //passes the data of the clicked button to the note menu manager
        MenuManager.Instance.noteMenuManager.data = data;
        //changes to the note menu
        MenuManager.Instance.ChangeMenu(MenuManager.Instance.noteMenuManager.gameObject);
        //clears the data since it's no longer needed
        data = null;
    }
}
