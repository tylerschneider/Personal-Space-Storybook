using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    public bool active = true;

    private void Start()
    {
        active = SettingsManager.Instance.GuidanceCircle;
        SetColor();
    }

    public void OnClick()
    {
        //toggles the setting
        active = !active;

        SetColor();
    }

    private void SetColor()
    {
        //changes the color of the button if it is enabled/disabled
        if (active)
        {
            GetComponent<Image>().color = Color.white;
        }
        else
        {
            GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
        }
    }
}