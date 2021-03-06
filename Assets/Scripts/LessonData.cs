using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class LessonData
{
    public System.DateTime date;
    public string lesson;
    public int attempts;
    public string note;
    public string time;
    public System.Guid guid;
}
