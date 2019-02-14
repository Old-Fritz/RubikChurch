using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    [SerializeField] private Text description;
    
    private static Interface instance;

    void Start()
    {
        instance = this;
    }

    public static Interface getI()
    {
        return instance;
    }
    
    public void changeDescription(String text)
    {
        description.text = text;
    }
    
    
}
