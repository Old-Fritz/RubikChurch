using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    [SerializeField] private Text description;
    [SerializeField] private Text subtitles;
    
    private int subsID = 0;
    
    public static Interface main { get; protected set; }

    void Start()
    {
        main = this;
    }
    
    public void changeDescription(String text)
    {
        description.text = text;
    }

    public void showSubtitles(String text, float time)
    {
        subtitles.text = text;
        StartCoroutine(clearSubtitles(time));
    }
    
    IEnumerator clearSubtitles(float time)
    {
        int id = ++subsID;
        yield return new WaitForSeconds(time);
        if (id == subsID)
            subtitles.text = "";
    }
    
    
}
