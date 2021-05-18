using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Lesson : MonoBehaviour
{
    public bool lessonEnabled;
    public string lessonProgress = "None";
    public bool complete;
    public TextAsset lessonText;
    public Conversation conversation;
    public DistanceManager.Classification answer = DistanceManager.Classification.None;
    public GameObject placedObject;
    public string lessonName;
    public string timePlayingStr;
    private TimeSpan timePlaying;
    private bool isPlaying;
    private float elapsedTime;

    private void Start()
    {
        isPlaying = false;
        elapsedTime = 0f;
    }

    public void BeginTimer()
    {
        isPlaying = true;
        
        Debug.Log("Timer Started");
        StartCoroutine(UpdateTimer());
    }

    public void StopTimer()
    {
        Debug.Log("Timer Stopped");
        isPlaying = false;
    }

    public void ResetTimer()
    {
        Debug.Log("Timer Reset");
        isPlaying = false;
        elapsedTime = 0f;
    }

    public string timeString()
    {
        return timePlayingStr;
    }

    private IEnumerator UpdateTimer()
    {
        while (isPlaying)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            timePlayingStr = timePlaying.ToString("mm':'ss");
            yield return null;
        }

    }
}
