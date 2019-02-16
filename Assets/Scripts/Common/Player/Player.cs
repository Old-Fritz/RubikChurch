using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static GameObject main{get;protected set;}
    
    void Start()
    {
        main = gameObject;
    }
}
