using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private Scene0 scene;
    
    public void onClick()
    {
        if (!scene.cubeUp)
            return;
        else
        {
            Scenes.loadScene(1);
            Scenes.goToScene(1);
            Scenes.unLoadScene(0);
        }
    }
}
