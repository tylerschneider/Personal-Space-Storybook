using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LessonButton : MonoBehaviour
{
    public GameObject lesson;
    public LessonLoader lessonLoader;
    public float pressTime = 1f;
    public float time;
    public bool pressed;
    public void OnClick()
    {
        if(lessonLoader.instructor)
        {
            lesson.GetComponent<Lesson>().lessonEnabled = !lesson.GetComponent<Lesson>().lessonEnabled;

            if(lesson.GetComponent<Lesson>().lessonEnabled)
            {
                GetComponent<Image>().color = Color.white;
            }
            else
            {
                GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
            }
        }
        else
        {
            //put lesson loading code for students here
        }

    }
    public void OnHold()
    {
        pressed = true;
    }
    public void OffHold()
    {
        pressed = false;
        time = 0;
    }


    public void Change()
    {
        if (lessonLoader.instructor)
        {
            MenuManager.Instance.LessonMenu(lesson);
        }
    }

    private void Update()
    {
        if(pressed)
        {
            time += Time.deltaTime;

            if(time >= pressTime)
            {
                time = 0;
                Change();
            }
        }
        else
        {
            time = 0;
        }

    }
}
