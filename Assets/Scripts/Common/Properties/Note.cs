using System;
using System.Collections.Generic;
using System.Net.Mime;
using Common.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Properties
{
    public class Note : MonoBehaviour
    {
        [TextArea][SerializeField] private List<String> notes;
    
    
        public void onClick()
        {
            Interface.main.showNotes(notes);
        }
    }
}
