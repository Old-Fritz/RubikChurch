using System;
using Common.Managers;
using Common.Properties;
using UnityEngine;

namespace Scene1
{
    public class SceneCur : MonoBehaviour
    {
        [SerializeField] private String grabHint;
        [SerializeField] private Spawn spawn;
        [SerializeField] private Spawn newSpawn;
        [SerializeField] private AudioClip soundtrack;

        private bool started;

        void Start()
        {
            // preload scene 3
            Scenes.unLoadScene(0);
            Scenes.loadScene(3);
        }

        private void OnEnable()
        {
            if (!started)
            {
                Music.set(soundtrack);
                started = true;
            }
            
            Interface.main.showSubtitles(grabHint, 5);
            
        }

        public void changeSpawn()
        {
            spawn.tag = "Untagged";
            newSpawn.tag = "Spawn";
        }
        
    }
}
