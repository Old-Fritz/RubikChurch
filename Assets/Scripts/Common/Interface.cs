using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    [SerializeField] private Text subtitles;

    public void changeSubtitles(String text)
    {
        subtitles.text = text;
    }
}
