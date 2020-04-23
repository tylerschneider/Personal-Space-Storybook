using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

public class HistoryLoader : MonoBehaviour
{
    public GameObject content;
    public GameObject historyRow;
    public Sprite bubble;
    public Sprite pencil;
    private void OnEnable()
    {
        DirectoryInfo info = new DirectoryInfo(Application.persistentDataPath + "/data/");
        FileInfo[] files = info.GetFiles().OrderByDescending(p => p.CreationTime).ToArray();
        foreach (FileInfo fileInfo in files)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(fileInfo.FullName, FileMode.Open);
            LessonData data = (LessonData)bf.Deserialize(file);
            file.Close();

            GameObject row = Instantiate(historyRow, content.transform);

            row.transform.Find("Date").GetComponent<Text>().text = data.date.ToString("MM/dd/yy");
            row.transform.Find("Lesson").GetComponent<Text>().text = data.lesson;
            row.transform.Find("Score").GetComponent<Text>().text = data.score.ToString();

            if (data.note == "")
            {
                row.transform.Find("Button").GetComponent<Image>().sprite = pencil;
            }
            else
            {
                row.transform.Find("Button").GetComponent<Image>().sprite = bubble;
            }

            row.transform.Find("Button").GetComponent<HistoryButton>().data = data;
        }
    }

    private void OnDisable()
    {
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }
    }

}