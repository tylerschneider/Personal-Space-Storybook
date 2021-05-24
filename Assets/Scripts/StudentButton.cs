using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudentButton : MonoBehaviour
{
    public string studentName;
    public System.Guid guid;
    
    public void OnClick()
    {
        StudentManager.Instance.selectedName = studentName;
        StudentManager.Instance.selectedStudent = guid;

        LessonManager.Instance.LoadEnabledLessons();

        StudentManager.Instance.SaveLastStudent();
    }

    public void OnClickDelete()
    {
        MenuManager.Instance.ChangeMenu(MenuManager.Instance.studentDeleteMenu);
        MenuManager.Instance.studentDeleteMenu.transform.Find("Label").GetComponent<Text>().text = studentName + " will now be deleted.";
        StudentManager.Instance.selectedDeleteGUID = guid;
    }

    private void Update()
    {
        if(StudentManager.Instance.selectedStudent == guid)
        {
            GetComponent<Button>().interactable = false;
        }
        else
        {
            GetComponent<Button>().interactable = true;
        }
    }
}
