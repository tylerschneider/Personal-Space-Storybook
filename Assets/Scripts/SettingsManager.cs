using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;

    public bool GuidanceCircle;

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

        if (File.Exists(Application.persistentDataPath + "/settings.save"))
        {
            LoadSettings();
        }
    }

    public void SetGuidanceCircle()
    {
        GuidanceCircle = !GuidanceCircle;

        SaveSettings();
    }

    public void SaveSettings()
    {
        Settings data = new Settings();

        data.GuidanceCircle = GuidanceCircle;

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
    }
}