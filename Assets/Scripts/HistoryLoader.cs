using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

public class HistoryLoader : MonoBehaviour
{
    //gameobject that holds the history table
    public GameObject content;
    //prefab of a row in the history table
    public GameObject historyRow;
    //sprites for the pencil/speech bubble buttons to display if a note is set
    public Sprite bubble;
    public Sprite pencil;
    private void OnEnable()
    {
        if(StudentManager.Instance.selectedName != "")
        {
            DirectoryInfo info = new DirectoryInfo(Application.persistentDataPath + "/" + StudentManager.Instance.selectedStudent + "/");

            //load the files in the data folder and store them in the files array in order of creation time (newest first)
            FileInfo[] files = info.GetFiles().OrderByDescending(p => p.CreationTime).ToArray();
            foreach (FileInfo fileInfo in files)
            {
                if(fileInfo.Name != "lessonData.save")
                {
                    //open each file
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream file = File.Open(fileInfo.FullName, FileMode.Open);
                    LessonData data = (LessonData)bf.Deserialize(file);
                    file.Close();

                    //create a new row in the table for each file
                    GameObject row = Instantiate(historyRow, content.transform);

                    //display the file's given date, lesson name, and score
                    row.transform.Find("Date").GetComponent<Text>().text = data.date.ToString("MM/dd/yy");
                    row.transform.Find("Lesson").GetComponent<Text>().text = data.lesson;
                    row.transform.Find("Attempts").GetComponent<Text>().text = data.attempts.ToString();
                    row.transform.Find("Time").GetComponent<Text>().text = data.time;

                    //display a pencil button if there is no note, or a speach bubble if there is a note
                    if (data.note == "")
                    {
                        row.transform.Find("Button").GetComponent<Image>().sprite = pencil;
                    }
                    else
                    {
                        row.transform.Find("Button").GetComponent<Image>().sprite = bubble;
                    }
                    //pass the file's data to the button so that it can be used by the note menu
                    row.transform.Find("Button").GetComponent<HistoryButton>().data = data;
                }
            }
        }
    }

    //displays only the history of the given lesson
    public void SortMenu(Text lesson)
    {
        foreach (Transform row in content.transform)
        {
            if(row.Find("Lesson").GetComponent<Text>().text != lesson.text)
            {
                Destroy(row.gameObject);
            }
        }
    }

    private void OnDisable()
    {
        //clears all of the displayed history rows in the table when the history menu is closed
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }
    }

}