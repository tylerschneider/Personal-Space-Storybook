﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class LessonManager : MonoBehaviour
{
    public static LessonManager Instance;
    private bool historyCreated;
    //!! for debug !!

    public Lesson selectedLesson;
    public Timer timer;
    public int reviewScore;

    void Start()
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

        //create the data folder if it doesn't exist when the app starts
        if (!Directory.Exists(Application.persistentDataPath + "/data"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/data");
        }
    }

    //Trigger to create a new history
    public void LessonHistoryTrigger()
    {
        //prevent duplicate history created
        if(historyCreated == false)
        {
            CreateLessonHistory(selectedLesson.lessonName, Random.Range(0, 20), selectedLesson.timeString());
            counter++;
        }
    }

    public void CreateLessonHistory(string lesson, int attempts, string time)
    {
        Debug.Log("Creating History");

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
        FileStream file = File.Create(Application.persistentDataPath + "/" + StudentManager.Instance.selectedStudent + "/" + guid + ".save");
        bf.Serialize(file, data);
        file.Close();
    }

    public void UpdateLessonNote(string note, System.Guid guid)
    {
        //read the lesson data file with the given guid
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/" + StudentManager.Instance.selectedStudent + "/" + guid + ".save", FileMode.Open);
        LessonData data = (LessonData)bf.Deserialize(file);
        file.Close();

        //update the note with the given note value
        data.note = note;

        //save over the existing data file with the updated one
        file = File.Create(Application.persistentDataPath + "/" + StudentManager.Instance.selectedStudent + "/" + guid + ".save");
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
        FileStream file = File.Create(Application.persistentDataPath + "/" + StudentManager.Instance.selectedStudent + "/lessonData.save");
        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadEnabledLessons()
    {
        //load the enabled lessons file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/" + StudentManager.Instance.selectedStudent + "/lessonData.save", FileMode.Open);
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

    public void ClearEnabledLessons()
    {
        foreach (Transform child in transform)
        {
            if(child != transform.GetChild(0))
            {
                child.GetComponent<Lesson>().lessonEnabled = false;
            }
            child.GetComponent<Lesson>().lessonProgress = "None";
        }

        Debug.Log("Clear Lesson Data");
    }

    public void DeleteAllHistory()
    {
        //get all the files in the data folder
        DirectoryInfo info = new DirectoryInfo(Application.persistentDataPath + "/" + StudentManager.Instance.selectedStudent + "/");
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

    public void CompleteReview()
    {
        selectedLesson.lessonProgress = "Pass";

        //if the auto lesson setting is enabled, find the next lesson and enable it
        if (SettingsManager.Instance.AutoLesson)
        {
            for (int i = 0; i < transform.childCount - 1; i++)
            {
                if (transform.GetChild(i).GetComponent<Lesson>().name == selectedLesson.name)
                {
                    if(transform.GetChild(i + 1))
                    {
                        transform.GetChild(i + 1).GetComponent<Lesson>().lessonEnabled = true;
                        SaveEnabledLessons();
                    }

                }
            }
        }

        ReviewBackButton();
    }

    public void ReviewBackButton()
    {
        ResetTimer();
        CreateLessonHistory(selectedLesson.lessonName, reviewScore, selectedLesson.timeString());
        SaveEnabledLessons();
        MenuManager.Instance.ChangeMenu(MenuManager.Instance.transform.Find("StudentLessons").gameObject);
        reviewScore = 0;
    }
}
