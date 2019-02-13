using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public void spawn(GameObject player)
    {
        // set player transform params as in spawn
        player.transform.localPosition = transform.localPosition;
        player.transform.localRotation = transform.localRotation;
        player.transform.parent = transform.parent;
        player.GetComponent<MouseRotation>().setDefault();
    }
}
