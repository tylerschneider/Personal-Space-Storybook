using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

public class StudentManager : MonoBehaviour
{
    public static StudentManager Instance;
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
    }

    public void CreateStudent(InputField inputField)
    {
        System.Guid guid = System.Guid.NewGuid();

        Student student = new Student();

        Debug.Log(guid);

        student.name = inputField.text;
        student.guid = guid;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + guid + ".data");
        Directory.CreateDirectory(Application.persistentDataPath + "/" + guid);
        bf.Serialize(file, student);
        file.Close();
    }

    public void DeleteStudent(System.Guid guid)
    {
        //save the lesson data file in the data folder
        File.Delete(Application.persistentDataPath + "/" + guid + ".data");
        Directory.Delete(Application.persistentDataPath + "/" + guid);
    }
}
