using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson : MonoBehaviour
{
    public bool lessonEnabled = true;
    public string lessonProgress = "None";
    public TextAsset lessonText;
    public AudioClip[] clips;
    public DistanceManager.Classification answer = DistanceManager.Classification.None;
    public GameObject placedObject;
    public string lessonName;
}
