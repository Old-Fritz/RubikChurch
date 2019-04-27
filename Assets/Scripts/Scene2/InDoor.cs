using System;
using Common.Managers;
using Common.Properties;
using UnityEngine;

namespace Scene2
{
    public class InDoor : MonoBehaviour
    {
        [SerializeField] private SceneCur scene;
        [SerializeField] private String closedDoorSubs;

        public void onClick()
        {
            if (scene.keyUp)
            {
                Transitor transitor = GetComponent<Transitor>();
                if(transitor)
                    transitor.transite();
            }
            else
            {
                Interface.main.showSubtitles(closedDoorSubs,3);
            }
        }
    }
}
