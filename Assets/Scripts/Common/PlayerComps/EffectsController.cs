﻿using System.Collections;
using System.Collections.Generic;
using MorePPEffects;
using UnityEngine;

public class EffectsController : MonoBehaviour
{
    [SerializeField] private GameObject camera;

    public void setEffectsActive(bool value)
    {
        // turn on post effects
        Headache headache = camera.GetComponent<Headache>();
        if (headache)
            headache.enabled = value;
        
        Waves waves = camera.GetComponent<Waves>();
        if (waves)
            waves.enabled = value;
        
        Wiggle wiggle = camera.GetComponent<Wiggle>();
        if (wiggle)
            wiggle.enabled = value;
        
        RadialBlur radialBlur = camera.GetComponent<RadialBlur>();
        if (radialBlur)
            radialBlur.enabled = value;
        
        // set far plane
        Camera cameraComp = camera.GetComponent<Camera>();
        if (camera)
        {
            if (value)
                cameraComp.farClipPlane = 100000;
            else
                cameraComp.farClipPlane = 100;
        }
           
    }
}
