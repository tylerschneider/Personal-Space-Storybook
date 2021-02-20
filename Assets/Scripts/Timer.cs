using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    private TimeSpan timePlaying;
    private bool isPlaying;
    private float elapsedTime;

    public string timePlayingStr;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        isPlaying = false;
    }

    public void BeginTimer()
    {
        isPlaying = true;
        elapsedTime = 0f;

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
