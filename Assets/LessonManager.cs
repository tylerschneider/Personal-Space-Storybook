using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class LessonManager : MonoBehaviour
{
    public static LessonManager Instance;
    int counter = 0;
    //public GameObject[] lessons;
    // Start is called before the first frame update
    void Start()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        if(!Directory.Exists(Application.persistentDataPath + "/data"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/data");
        }
    }

    public void CreateRandomLesson()
    {
        int num1 = Random.Range(0, 10);
        int num2 = Random.Range(0, 100);
        CreateLessonHistory("Lesson " + counter, num2);
        counter++;
    }

    public void CreateLessonHistory(string lesson, int score)
    {
        System.Guid guid = System.Guid.NewGuid();

        LessonData data = new LessonData();

        data.date = System.DateTime.Now;
        data.lesson = lesson;
        data.score = score;
        data.note = "";
        data.guid = guid;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/data/" + guid + ".save");
        bf.Serialize(file, data);
        file.Close();
    }

    public void UpdateLessonNote(string note, System.Guid guid)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/data/" + guid + ".save", FileMode.Open);
        LessonData data = (LessonData)bf.Deserialize(file);
        file.Close();

        data.note = note;

        file = File.Create(Application.persistentDataPath + "/data/" + guid + ".save");
        bf.Serialize(file, data);
        file.Close();
    }
}
