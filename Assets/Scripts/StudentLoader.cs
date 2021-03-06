using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class StudentLoader : MonoBehaviour
{
    //gameobject that holds the student buttons
    public GameObject content;
    //prefab for the student button
    public GameObject studentButton;

    private void OnEnable()
    {
        //destroy any buttons already loaded
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }

        BinaryFormatter bf = new BinaryFormatter();
        string[] files = Directory.GetFiles(Application.persistentDataPath + "/", "*.data");
        Debug.Log(files);

        //for each student
        foreach(string studentFile in files)
        {
                FileStream file = File.Open(studentFile, FileMode.Open);
                Student student = (Student)bf.Deserialize(file);
                file.Close();

                GameObject newButton = Instantiate(studentButton, content.transform);
                newButton.GetComponent<StudentButton>().guid = student.guid;
                newButton.transform.Find("Text").GetComponent<Text>().text = student.name;

        }
    }
}
