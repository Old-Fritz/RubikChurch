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
            Interface.main.showSubtitles(unReadyText, 3);
        else
        {
            // move accepted in scene1
            Move playerMove = Player.main.GetComponent<Move>();
            if (playerMove)
                playerMove.moveAccepted = true;
            
            Scenes.loadScene(1);
            Scenes.goToScene(1);
            Scenes.unLoadScene(0);
            Scenes.loadScene(2);
        }
    }
}
