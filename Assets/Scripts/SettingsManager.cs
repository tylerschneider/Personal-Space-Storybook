using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;

    public GameObject guidanceButton;
    public GameObject autoButton;
    public GameObject vibrateButton;

    public bool GuidanceCircle;
    public bool AutoLesson;
    public bool Vibration;

    private void Start()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            #if UNITY_IOS
            Debug.Log("Iphone");
            Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
            #endif
        }
        else
        {
            Destroy(gameObject);
        }

        //if a settings file exists, load them. If not, create a file.
        if (File.Exists(Application.persistentDataPath + "/settings.save"))
        {
            LoadSettings();
        }
        else
        {
            SaveSettings();
        }
    }

    public void SetGuidanceCircle()
    {
        GuidanceCircle = !GuidanceCircle;

        SaveSettings();
    }

    public void SetAutoLesson()
    {
        AutoLesson = !AutoLesson;

        SaveSettings();
    }
    public void SetVibration()
    {
        Vibration = !Vibration;

        SaveSettings();
    }

    public void SaveSettings()
    {
        Settings data = new Settings();

        data.GuidanceCircle = GuidanceCircle;
        data.AutoLesson = AutoLesson;
        data.Vibration = Vibration;

        //save the settings file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/settings.save");
        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadSettings()
    {
        //load the settings file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/settings.save", FileMode.Open);
        Settings data = (Settings)bf.Deserialize(file);
        file.Close();

        GuidanceCircle = data.GuidanceCircle;
        AutoLesson = data.AutoLesson;
        Vibration = data.Vibration;
    }

    private void Update()
    {
        //make sure the buttons are the correct color when the setting is on/off
        SetButtonColor(guidanceButton, GuidanceCircle);
        SetButtonColor(autoButton, AutoLesson);
        SetButtonColor(vibrateButton, Vibration);
    }

    private void SetButtonColor(GameObject button, bool state)
    {
        if (!state)
        {
            button.GetComponent<Image>().color = Color.white;
        }
        else
        {
            button.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
        }
    }
}