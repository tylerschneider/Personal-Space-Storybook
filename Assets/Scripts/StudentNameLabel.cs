using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudentNameLabel : MonoBehaviour
{
    void Update()
    {
        if(StudentManager.Instance.selectedName != null && StudentManager.Instance.selectedName != "")
        {
            GetComponent<Text>().text = StudentManager.Instance.selectedName;
        }
    }
}
