using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    public static SettingsButton Instance;
    public bool pressed;

    private void Start()
    {
        if(!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void OnClick()
    {
        pressed = !pressed;

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
