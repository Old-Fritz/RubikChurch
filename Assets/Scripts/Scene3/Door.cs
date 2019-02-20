using System;
using System.Collections;
using System.Collections.Generic;
using Common.Managers;
using Common.Properties;
using UnityEngine;

namespace Scene3
{
    public class Door : MonoBehaviour
    { 
        [SerializeField] private SceneCur scene;
        [SerializeField] private String onClickSubs;
        
        private bool opened = false;

        public void onClick()
        {
            Interface.main.showSubtitles(onClickSubs);
        }
        
        public void pray()
        {
            if (scene.generatorLaunched)
                scene.portraitPrayed = true;
            if (scene.portraitRespected && !opened)
                open();
        }
        
        public void respect()
        {
            if (scene.generatorLaunched)
                scene.portraitRespected = true;
            if (scene.portraitPrayed && !opened)
                open();
        }

        private void open()
        {
            ClickMovable move = GetComponent<ClickMovable>();
            if (move)
            {
                move.move();
                opened = true;
            }
        }
    }
}
