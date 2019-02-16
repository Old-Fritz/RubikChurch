using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private List<String> notes;
    
    
    public void onClick()
    {
        Interface.main.showNotes(notes);
    }
}
