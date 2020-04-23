using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HistoryButton : MonoBehaviour
{
    public LessonData data;
    public void OnClick()
    {
        MenuManager.Instance.noteMenuManager.data = data;
        MenuManager.Instance.ChangeMenu(MenuManager.Instance.noteMenuManager.gameObject);
        data = null;
    }
}
