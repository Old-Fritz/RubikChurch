using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private Scene0 scene;
    [SerializeField] private String unReadyText;
    
    public void onClick()
    {
        if (!scene.cubeUp)
            Interface.getI().showSubtitles(unReadyText, 3);
        else
        {
            Scenes.loadScene(1);
            Scenes.goToScene(1);
            Scenes.unLoadScene(0);
        }
    }
}
