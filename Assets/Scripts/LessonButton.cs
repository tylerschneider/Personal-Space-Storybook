using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LessonButton : MonoBehaviour
{
    public static LessonButton instance;
    public GameObject lesson;
    public LessonLoader lessonLoader;
    public float pressTime = 1f;
    public float time;
    public bool pressed;
    public int selectedIndex;

    public void OnClick()
    {
        //check if the button is in the instructor menu
        if (lessonLoader.instructor)
        {
            if(StudentManager.Instance.selectedStudent != Guid.Empty)
            {
                //toggle the button
                lesson.GetComponent<Lesson>().lessonEnabled = !lesson.GetComponent<Lesson>().lessonEnabled;

                //change the button's color when enabled/disabled
                if (lesson.GetComponent<Lesson>().lessonEnabled)
                {
                    GetComponent<Image>().color = Color.white;
                }
                else
                {
                    GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
                }

                //save whether the lesson has been enabled/disabled when it is toggled
                LessonManager.Instance.SaveEnabledLessons();
            }
        }
        else
        {
            LessonManager.Instance.selectedLesson = lesson.GetComponent<Lesson>();
            SceneManager.LoadScene("Main");
            MenuManager.Instance.ChangeMenu(null);
            LessonManager.Instance.BeginTimer();
            LessonManager.Instance.AttemptsIncrease();
        }
    }
    public void OnHold()
    {
        //start holding
        pressed = true;
    }

    public void OffHold()
    {
        //stop holding and reset the timer
        pressed = false;
        time = 0;
    }


    public void Change()
    {
        //change menus if in the instructor menu
        if (lessonLoader.instructor)
        {
            MenuManager.Instance.LessonMenu(lesson);
        }
    }

    private void Update()
    {
        //tracks how long a button has been held down
        if (pressed)
        {
            time += Time.deltaTime;

            if (time >= pressTime)
            {
                time = 0;
                //if held down for the full press time, change the menu to the lesson's summary
                Change();
            }
        }
        else
        {
            time = 0;
        }

    }




}