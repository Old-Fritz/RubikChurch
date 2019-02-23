using System;
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

        private bool drilled, fueled, prayed;

        public void onClick()
        {
            if (!drilled)
            {
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
                    Interface.main.showSubtitles(afterFuelUpSubs);
            }
        }
        
        private void launch()
        {
            lights.SetActive(true);
            Interface.main.showSubtitles(afterLaunchUpSubs);
            scene.generatorLaunched = true;
        }
    }
    
    
}
