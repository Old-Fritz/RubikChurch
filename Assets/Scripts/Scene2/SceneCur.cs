using System;
using System.Collections;
using System.Collections.Generic;
using Common.Managers;
using Common.Properties;
using UnityEngine;

public class SceneCur : MonoBehaviour
{
    [SerializeField] private String flashlightHint;
    
    public bool keyUp { get; set; }
        
    private void OnEnable()
    {
        Interface.main.showSubtitles(flashlightHint, 5);
    }
}
