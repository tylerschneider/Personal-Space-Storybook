using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LessonLoader : MonoBehaviour
{
    //gameobject that holds the lesson buttons
    public GameObject content;
    //prefab for the lesson button
    public GameObject lessonButton;
    //whether the menu is the instructor menu or the student menu

    public bool instructor;

    private void OnEnable()
    {
        //destroy any buttons already loaded
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }

        //for each lesson
        for (var i = 0; i < LessonManager.Instance.transform.childCount; i++)
        {
            //get the lesson gameobject
            GameObject lesson = LessonManager.Instance.transform.GetChild(i).gameObject;

            //if the lesson is enabled or in instructor menu
            if (instructor)
            {
                //create new button
                GameObject newButton = Instantiate(lessonButton, content.transform);

                //set the correct progress icon
                newButton.transform.Find(lesson.GetComponent<Lesson>().lessonProgress).gameObject.SetActive(true);

                //fade the button if it is not available for the student
                if (!lesson.GetComponent<Lesson>().lessonEnabled)
                {
                    newButton.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
                }

                //set the text on the button to match the lesson
                newButton.transform.Find("Text").GetComponent<Text>().text = lesson.GetComponent<Lesson>().lessonName;

                //assign the lesson to the button
                newButton.GetComponent<LessonButton>().lesson = lesson;

                //assign this lesson loader to the button
                newButton.GetComponent<LessonButton>().lessonLoader = this;
            }


            if (!instructor)
            {
                if(lesson.GetComponent<Lesson>().lessonEnabled)
                {
                    //create new button
                    GameObject newButton = Instantiate(lessonButton, content.transform);

                    //set the text on the button to match the lesson
                    newButton.transform.Find("Text").GetComponent<Text>().text = lesson.GetComponent<Lesson>().lessonName;

                    //set the correct progress icon
                    newButton.transform.Find(lesson.GetComponent<Lesson>().lessonProgress).gameObject.SetActive(true);

                    //assign the lesson to the button
                    newButton.GetComponent<LessonButton>().lesson = lesson.gameObject;

                    //assign this lesson loader to the button
                    newButton.GetComponent<LessonButton>().lessonLoader = this;
                }
            }
        }


    }
}
