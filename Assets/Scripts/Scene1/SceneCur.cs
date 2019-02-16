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
        
        private void OnEnable()
        {
            Interface.main.showSubtitles(grabHint, 5);
        }

        public void changeSpawn()
        {
            spawn.tag = null;
            newSpawn.tag = "Spawn";
        }
        
    }
}
