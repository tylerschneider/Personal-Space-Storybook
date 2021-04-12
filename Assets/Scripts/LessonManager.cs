using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class LessonManager : MonoBehaviour
{
    public static LessonManager Instance;

    //!! for debug !!
    int counter = 0;

    public Lesson selectedLesson;
    public Timer timer;
    private int lessonAttempts;
    void Start()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            timer = Timer.instance;
        }
        else
        {
            Destroy(this.gameObject);
        }

        //create the data folder if it doesn't exist when the app starts
        if (!Directory.Exists(Application.persistentDataPath + "/data"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/data");
        }

        //load which lessons are enabled if there is a save
        if (File.Exists(Application.persistentDataPath + "/lessonData.save"))
        {
            LoadEnabledLessons();
        }
    }

    public void SelectedIndex(int index)
    {
        selectedLesson = this.gameObject.transform.GetChild(index - 1).GetComponent<Lesson>();
        Debug.Log("selected " + selectedLesson.name);
    }



    public void BeginTimer()
    {
        if (selectedLesson != null)
            selectedLesson.BeginTimer();
    }
    public void EndTimer()
    {
        if (selectedLesson != null)
            selectedLesson.StopTimer();
    }
    public void ResetTimer()
    {
        if (selectedLesson != null)
            selectedLesson.ResetTimer();
    }
    public void AttemptsIncrease()
    {
        selectedLesson.Attempt++;
        Debug.Log("selected " + selectedLesson.name);
        Debug.Log(selectedLesson.Attempt);
    }

    //!! for debug !!
    public void CreateRandomLesson()
    {
        if(selectedLesson != null)
        {
            CreateLessonHistory(selectedLesson.lessonName, selectedLesson.Attempt, selectedLesson.timeString());
            counter++;

        }
        
    }

    public void CreateLessonHistory(string lesson, int attempts, string time)
    {
        //create a new guid for the file name
        System.Guid guid = System.Guid.NewGuid();

        LessonData data = new LessonData();

        data.date = System.DateTime.Now;
        data.lesson = lesson;
        data.attempts = attempts;
        data.time = time;
        data.note = "";
        data.guid = guid;

        //save the lesson data file in the data folder
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/data/" + guid + ".save");
        bf.Serialize(file, data);
        file.Close();
    }

    public void UpdateLessonNote(string note, System.Guid guid)
    {
        //read the lesson data file with the given guid
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/data/" + guid + ".save", FileMode.Open);
        LessonData data = (LessonData)bf.Deserialize(file);
        file.Close();

        //update the note with the given note value
        data.note = note;

        //save over the existing data file with the updated one
        file = File.Create(Application.persistentDataPath + "/data/" + guid + ".save");
        bf.Serialize(file, data);
        file.Close();
    }

    public void SaveEnabledLessons()
    {
        EnabledLessons data = new EnabledLessons();

        //get each lesson gameobject and record if it enabled and its progress
        foreach(Transform child in transform)
        {
            data.enabledLesson.Add(child.GetComponent<Lesson>().lessonEnabled);
            data.progress.Add(child.GetComponent<Lesson>().lessonProgress);
        }

        //save the file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/lessonData.save");
        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadEnabledLessons()
    {
        //load the enabled lessons file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/lessonData.save", FileMode.Open);
        EnabledLessons data = (EnabledLessons)bf.Deserialize(file);
        file.Close();

        //set each of the lesson gameobjects' data to whether it is enabled and its progress
        for (int i = 0; i < data.enabledLesson.Count; i++)
        {
            if(transform.GetChild(i) != null)
            {
                transform.GetChild(i).GetComponent<Lesson>().lessonEnabled = data.enabledLesson[i];
                transform.GetChild(i).GetComponent<Lesson>().lessonProgress = data.progress[i];
            }
        }
    }

    public void DeleteAllHistory()
    {
        //get all the files in the data folder
        DirectoryInfo info = new DirectoryInfo(Application.persistentDataPath + "/data/");
        FileInfo[] files = info.GetFiles();

        //delete each file
        foreach (FileInfo fileInfo in files)
        {
            File.Delete(fileInfo.FullName);
        }

        //reset each lesson's progress to none
        foreach (Transform child in transform)
        {
            child.GetComponent<Lesson>().lessonProgress = "None";
        }

        //save to make sure the change in lesson progress is recorded
        SaveEnabledLessons();
    }
}
