using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class HomeNote : MonoBehaviour
{
    [SerializeField] private GameObject movedPosition;
    
    
    private bool moved;
    
    
    public void onClick()
    {
        if (!moved)
        {
            transform.position = movedPosition.transform.position;
            moved = true;
        }
    }
}
