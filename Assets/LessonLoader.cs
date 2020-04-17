using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LessonLoader : MonoBehaviour
{
    public GameObject content;
    public GameObject lessonButton;
    public bool instructor;

    private void OnEnable()
    {
        foreach(Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }

        //for each lesson
        for (var i = 0; i < LessonManager.Instance.transform.childCount; i++)
        {
            //get the lesson gameobject
            GameObject lesson = LessonManager.Instance.transform.GetChild(i).gameObject;

            //if the lesson is enabled or in instructor menu
            if(lesson.GetComponent<Lesson>().lessonEnabled || instructor)
            {
                //create new button
                GameObject newButton = Instantiate(lessonButton, content.transform);

                //set the correct progress icon
                newButton.transform.Find(lesson.GetComponent<Lesson>().lessonProgress).gameObject.SetActive(true);

                //fade the button if it is not available for the student
                if(!lesson.GetComponent<Lesson>().lessonEnabled)
                {
                    newButton.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
                }

                //set the text on the button to match the lesson
                newButton.transform.Find("Text").GetComponent<Text>().text = lesson.name;

                //assign the lesson to the button
                newButton.GetComponent<LessonButton>().lesson = lesson;

                //assign this lesson loader to the button
                newButton.GetComponent<LessonButton>().lessonLoader = this;
            }

        }
    }
}
