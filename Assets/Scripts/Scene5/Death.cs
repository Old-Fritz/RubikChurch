using System;
using Common.Managers;
using Common.PlayerComps;
using Common.Properties;
using UnityEngine;

namespace Scene5
{
    public class Death : MonoBehaviour
    {
        [SerializeField] private String deathHint;

        private bool waitingDeath, waited;

        // Update is called once per frame
        void Update()
        {
            // Die on press
            if (waitingDeath)
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    // start final
                    Transitor transition = GetComponent<Transitor>();
                    if(transition)
                        transition.transite();
                    waitingDeath = false;
                    waited = true;
                    
                    // set ending
                    Save save = Player.main.GetComponent<Save>();
                    if (save)
                        save.currentEnd = Save.End.BAD;
                }
            }
        }

        public void waitDeath()
        {
            if (!waited)
            {
                waitingDeath = true;
                Interface.main.showSubtitles(deathHint,1488);
            }
        }
    }
}
