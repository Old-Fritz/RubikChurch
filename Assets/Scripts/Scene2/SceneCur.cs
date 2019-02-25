using System;
using Common.Managers;
using UnityEngine;

namespace Scene2
{
    public class SceneCur : MonoBehaviour
    {
        [SerializeField] private String flashlightHint;
    
        public bool keyUp { get; set; }

        void Start()
        {
            keyUp = false;
        }
        private void OnEnable()
        {
            Interface.main.showSubtitles(flashlightHint, 5);
        }
    }
}
