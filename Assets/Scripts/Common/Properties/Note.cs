using System;
using System.Collections.Generic;
using Common.Managers;
using UnityEngine;

namespace Common.Properties
{
    public class Note : MonoBehaviour
    {
        [SerializeField] private List<String> notes;
    
    
        public void onClick()
        {
            Interface.main.showNotes(notes);
        }
    }
}
