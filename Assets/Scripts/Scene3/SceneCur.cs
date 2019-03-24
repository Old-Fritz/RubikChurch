using System.Collections;
using System.Collections.Generic;
using Common.Managers;
using UnityEngine;

namespace Scene3
{
    public class SceneCur : MonoBehaviour
    {
        [SerializeField] private AudioClip soundtrack;

        void Start()
        {
            // preload scene
            Scenes.unLoadScene(1);
            Scenes.unLoadScene(2);
            Scenes.loadScene(4);
        }

        private void OnEnable()
        {
            Music.set(soundtrack);
        }

        public bool keyUp { get; set; }
        public bool drillUp { get; set; }
        public bool fuelUp { get; set; }
        public bool generatorPrayed { get; set; }
        public bool generatorLaunched { get; set; }
        public bool portraitRespected { get; set; }
        public bool portraitPrayed { get; set; }
    }
}
