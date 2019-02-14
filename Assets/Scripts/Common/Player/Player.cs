using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static GameObject player
    {
        get;
        protected set;
    }
    
    void Start()
    {
        player = gameObject;
    }
}
