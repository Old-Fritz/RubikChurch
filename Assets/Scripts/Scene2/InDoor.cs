using System;
using Common.Managers;
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
                Scenes.goToScene(3);
            }
            else
            {
                Interface.main.showSubtitles(closedDoorSubs,3);
            }
        }
    }
}
