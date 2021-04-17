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
        StudentManager.Instance.DeleteStudent(guid);
        if(StudentManager.Instance.selectedStudent == guid)
        {
            StudentManager.Instance.selectedStudent = System.Guid.Empty;
            StudentManager.Instance.name = null;
        }
        Destroy(gameObject);
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