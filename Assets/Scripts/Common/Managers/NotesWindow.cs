using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Managers
{
    public class NotesWindow : MonoBehaviour
    {
        [SerializeField] private Text text;
        [SerializeField] private Text numbers;
    
        private List<String> notes;
        private int currentNote = 0;

        // Update is called once per frame
        void Update()
        {
            if(Input.GetMouseButtonUp(0))
                rightNote();
            if(Input.GetMouseButtonUp(1))
                leftNote();
            if(Input.GetKeyUp(KeyCode.Escape))
                gameObject.SetActive(false);
        }
    
        public void showNotes(List<String> notesStr)
        {
            notes = notesStr;
            currentNote = 0;
            showText();
        }
    
        private void leftNote()
        {
            if (currentNote > 0)
            {
                currentNote--;
                showText();
            }
        }

        private void rightNote()
        {
            if (currentNote < notes.Count - 1)
            {
                currentNote++;
                showText();
            }
        }

        private void showText()
        {
            if (currentNote >= 0 && currentNote < notes.Count)
            {
                text.text = notes[currentNote];
                numbers.text = (currentNote + 1) + "/" + notes.Count;
            }
        
        }
    }
}
