using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Managers
{
    public class Interface : MonoBehaviour
    {
        [SerializeField] private Text description;
        [SerializeField] private Text subtitles;
        [SerializeField] private NotesWindow notes;
    
    
        private int subsID = 0;


        public bool notesShowed { get {return notes.gameObject.activeInHierarchy;} }
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

        public void showNotes(List<String> notesStr)
        {
            notes.gameObject.SetActive(true);
            notes.showNotes(notesStr);
        }
    
        IEnumerator clearSubtitles(float time)
        {
            int id = ++subsID;
            yield return new WaitForSeconds(time);
            if (id == subsID)
                subtitles.text = "";
        }

    
    
    
    }
}
