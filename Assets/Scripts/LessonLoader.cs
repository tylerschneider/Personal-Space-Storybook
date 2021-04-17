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
    public GameObject testButton;
    public bool instructor;
    private GameObject lesson1;
    private int enabledLesson = 1;
    private bool deb;

    private int currentLesson = 1;
    //private int currentLessonIndex = 0; 
    private void OnEnable()
    {
        //destroy any buttons already loaded
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
            if(instructor)
            {
                lesson.GetComponent<Lesson>().lessonEnabled = true;
                deb = lesson.GetComponent<Lesson>().lessonEnabled;
                Debug.Log(deb);
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

        lesson1 = LessonManager.Instance.transform.GetChild(0).gameObject;
        if (!instructor)
        {
            currentLesson = 1;
            enabledLesson = 1;
            for (var i = 0; i < LessonManager.Instance.transform.childCount; i++)
            {
                GameObject lesson = LessonManager.Instance.transform.GetChild(i).gameObject;
                lesson.GetComponent<Lesson>().lessonEnabled = false;
            }
            lesson1.GetComponent<Lesson>().lessonEnabled = true;
            //create new button
            GameObject newButton = Instantiate(lessonButton, content.transform);
            
            //set the correct progress icon
            newButton.transform.Find(lesson1.GetComponent<Lesson>().lessonProgress).gameObject.SetActive(true);

            //fade the button if it is not available for the student
            if (!lesson1.GetComponent<Lesson>().lessonEnabled)
            {
                newButton.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
            }

            //set the text on the button to match the lesson
            newButton.transform.Find("Text").GetComponent<Text>().text = lesson1.name;

            //assign the lesson to the button
            newButton.GetComponent<LessonButton>().lesson = lesson1;

            //assign this lesson loader to the button
            newButton.GetComponent<LessonButton>().lessonLoader = this;

            //GameObject newButton2 = Instantiate(testButton, content.transform);
            //newButton2.GetComponent<TestButton>().lesson = lesson1;

            //newButton2.GetComponent<TestButton>().lessonLoader = this;

            
        }
    }

    private IEnumerator UpdateLesson()
    {
        while (currentLesson < enabledLesson)
        {
            Debug.Log("creating a lesson");
            //if(lesson1.GetComponent<Lesson>().lessonProgress == "Done")
            //{
            currentLesson++;
            GameObject lesson = LessonManager.Instance.transform.GetChild(currentLesson-1).gameObject;

                lesson.GetComponent<Lesson>().lessonEnabled = true;
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
                newButton.transform.Find("Text").GetComponent<Text>().text = lesson.name;

                //assign the lesson to the button
                newButton.GetComponent<LessonButton>().lesson = lesson;

                //assign this lesson loader to the button
                newButton.GetComponent<LessonButton>().lessonLoader = this;
            
            Debug.Log(currentLesson +" : " +enabledLesson);
            //}
            yield return null;
        }
        if (currentLesson > enabledLesson)
        {
            Destroy(content.transform.GetChild(currentLesson-1).gameObject);
            currentLesson--;
        }

    }

    private IEnumerator UpdateLessonProgress()
    {


                //get the lesson gameobject
                GameObject lesson = LessonManager.Instance.transform.GetChild(currentLesson-1).gameObject;
                if(lesson.GetComponent<Lesson>().complete == true)
                {
                    enabledLesson++;
                    Debug.Log(enabledLesson);
                }

                yield return null;


    }

    private void Update()
    {
        StartCoroutine(UpdateLesson());
        StartCoroutine(UpdateLessonProgress());
    }

}
