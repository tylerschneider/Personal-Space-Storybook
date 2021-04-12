using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestButton : MonoBehaviour
{
    public static TestButton instance;
    public GameObject lesson;
    public LessonLoader lessonLoader;
    // Start is called before the first frame update
    public void OnClick()
    {

        Debug.Log("match");
    }
}
