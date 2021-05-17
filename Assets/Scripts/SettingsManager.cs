using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;

    public GameObject guidanceButton;
    public GameObject autoButton;

    public bool GuidanceCircle;
    public bool AutoLesson;

    private void Start()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
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

    public void SaveSettings()
    {
        Settings data = new Settings();

        data.GuidanceCircle = GuidanceCircle;
        data.AutoLesson = AutoLesson;

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
    }

    private void Update()
    {
        //make sure the buttons are the correct color when the setting is on/off
        SetButtonColor(guidanceButton, GuidanceCircle);
        SetButtonColor(autoButton, AutoLesson);
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