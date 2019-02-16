using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene0 : MonoBehaviour
{
    public bool cubeUp { get; set; }
    public bool cubeTouch { get; set; }

    void Start()
    {
        Move playerMove = Player.main.GetComponent<Move>();
        if (playerMove)
            playerMove.moveAccepted = false;
    }
}