using System;
using System.Collections;
using System.Collections.Generic;
using Common.Managers;
using UnityEngine;

public class InDoor : MonoBehaviour
{
    [SerializeField] private SceneCur scene;
    [SerializeField] private String closedDoorSubs;

    public void onClick()
    {
        if (scene.keyUp)
        {
            Scenes.loadScene(3);
            Scenes.goToScene(3);
        }
        else
        {
            Interface.main.showSubtitles(closedDoorSubs,3);
        }
    }
}
