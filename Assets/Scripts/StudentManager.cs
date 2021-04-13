using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

public class StudentManager : MonoBehaviour
{
    public static StudentManager Instance;
    public string selectedName;
    public System.Guid selectedStudent;

    private void Start()
    {
        if(!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else 
        {
            Destroy(this.gameObject);
        }

        LoadLastStudent();
    }

    public void CreateStudent(InputField inputField)
    {
        System.Guid guid = System.Guid.NewGuid();

        Student student = new Student();

        student.name = inputField.text;
        selectedName = inputField.text;
        student.guid = guid;
        selectedStudent = guid;
        
        Directory.CreateDirectory(Application.persistentDataPath + "/" + guid);

        LessonManager.Instance.ClearEnabledLessons();
        LessonManager.Instance.SaveEnabledLessons();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + guid + ".data");

        bf.Serialize(file, student);
        file.Close();

        StudentManager.Instance.SaveLastStudent();
    }

    public void DeleteStudent(System.Guid guid)
    {
        File.Delete(Application.persistentDataPath + "/" + guid + ".data");
        Directory.Delete(Application.persistentDataPath + "/" + guid);
    }

    public void SaveLastStudent()
    {
        Student student = new Student();

        student.guid = selectedStudent;
        student.name = selectedName;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/last.save");
        bf.Serialize(file, student);
        file.Close();
    }

    public void LoadLastStudent()
    {
        if (File.Exists(Application.persistentDataPath + "/last.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/last.save", FileMode.Open);
            Student data = (Student)bf.Deserialize(file);
            file.Close();

            selectedStudent = data.guid;
            selectedName = data.name;

            LessonManager.Instance.LoadEnabledLessons();
        }
    }
}
