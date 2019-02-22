using System;
using System.Collections;
using System.Collections.Generic;
using Common.Managers;
using UnityEngine;

public class ClickSubs : MonoBehaviour
{
    [SerializeField] private String subs;
    [SerializeField] private float time = 3;

    public void onClick()
    {
        Interface.main.showSubtitles(subs,time);
    }
}
