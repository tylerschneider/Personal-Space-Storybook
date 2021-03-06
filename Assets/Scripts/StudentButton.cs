using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudentButton : MonoBehaviour
{
    public System.Guid guid;
    
    public void OnClick()
    {
        StudentManager.Instance.selectedStudent = guid;
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
