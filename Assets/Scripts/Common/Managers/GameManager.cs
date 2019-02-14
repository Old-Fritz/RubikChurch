using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // go to start scene
        Scenes.Init();
        Scenes.loadScene(1);
        Scenes.goToScene(1);
    }

}
