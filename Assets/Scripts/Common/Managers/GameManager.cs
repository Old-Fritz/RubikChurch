using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        
        // move disabled start scene1
        Move playerMove = Player.player.GetComponent<Move>();
        if (playerMove)
            playerMove.moveAccepted = true;
        
        // go to start scene
        Scenes.Init();
        Scenes.loadScene(1);
        Scenes.goToScene(1);
    }

}
