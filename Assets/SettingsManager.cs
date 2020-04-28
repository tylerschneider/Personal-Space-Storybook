using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public bool option1;

    public void SetOption1()
    {
        option1 = !option1;
    }
}
