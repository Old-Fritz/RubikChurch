using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCube : MonoBehaviour
{
    [SerializeField] private float correctNumber;
    
    public float number
    {
        get { return correctNumber; }
    }
}
