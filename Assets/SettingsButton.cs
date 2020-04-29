using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    public bool pressed;

    public void OnClick()
    {
        //toggles the setting
        pressed = !pressed;

        //changes the color of the button if it is enabled/disabled
        if (pressed)
        {
            GetComponent<Image>().color = Color.white;
        }
        else
        {
            GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
        }
    }
}
