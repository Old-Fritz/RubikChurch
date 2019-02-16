using System.Collections;
using System.Collections.Generic;
using Common.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutDoor : MonoBehaviour
{
    public void onClick()
    {
        Scenes.goToScene(1);
    }

}
