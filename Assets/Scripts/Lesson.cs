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
    public AudioClip[] clips;
    public DistanceManager.Classification answer = DistanceManager.Classification.None;
    public GameObject placedObject;
    public string lessonName;
    public string timePlayingStr;
    private TimeSpan timePlaying;
    private bool isPlaying;
    private float elapsedTime;
    public int Attempt;

    public string Test()
    {
        return lessonName;
    }

    // Start is called before the first frame update

    private void Start()
    {
        isPlaying = false;
        elapsedTime = 0f;
        Attempt = 0;
    }

    public void BeginTimer()
    {
        isPlaying = true;
        
        Debug.Log(isPlaying);
        StartCoroutine(UpdateTimer());
    }

    public void StopTimer()
    {
        isPlaying = false;
    }

    public void ResetTimer()
    {
        isPlaying = false;
        elapsedTime = 0f;
        Attempt = 0;
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
            Debug.Log(timePlayingStr);
            yield return null;
        }

    }
}
