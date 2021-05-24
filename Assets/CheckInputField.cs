using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckInputField : MonoBehaviour
{
    public GameObject confirmButton;

    void Update()
    {
        if(GetComponent<Text>().text.Trim() != "")
        {
            confirmButton.SetActive(true);
        }
        else
        {
            confirmButton.SetActive(false);
        }
    }
}
