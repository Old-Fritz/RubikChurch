﻿using System;
using Common.Managers;
using UnityEngine;

namespace Scene3
{
    public class Generator : MonoBehaviour
    {
        [SerializeField] private SceneCur scene;
        [SerializeField] private GameObject lights;
        [SerializeField] private String startSubs;
        [SerializeField] private String afterDrillUpSubs;
        [SerializeField] private String afterFuelUpSubs;
        [SerializeField] private String afterLaunchUpSubs;
        [SerializeField] private AudioClip generatorPlay;

        private AudioSource source;
        private bool drilled, fueled, prayed;

        private void Start()
        {
            source = GetComponent<AudioSource>();
        }

        public void onClick()
        {
            if (!drilled)
            {
                source.Play();
                if (scene.drillUp)
                {
                    drilled = true;
                    Interface.main.showSubtitles(afterDrillUpSubs);
                }
                else
                    Interface.main.showSubtitles(startSubs);
            }
            else if (!fueled)
            {
                source.Play();
                if (scene.fuelUp)
                {
                    fueled = true;
                    Interface.main.showSubtitles(afterFuelUpSubs);
                }
                else
                    Interface.main.showSubtitles(afterDrillUpSubs);
            }
            else if (!prayed)
            {
                if (scene.generatorPrayed)
                {
                    prayed = true;
                    launch();
                }
                else
                {
                    source.Play();
                    Interface.main.showSubtitles(afterFuelUpSubs);
                }
            }
        }
        
        private void launch()
        {
            source.clip = generatorPlay;
            source.loop = true;
            source.volume = 0.5f;
            source.Play();
            
            lights.SetActive(true);
            Interface.main.showSubtitles(afterLaunchUpSubs);
            scene.generatorLaunched = true;
        }
    }
    
    
}
