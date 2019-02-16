using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    [SerializeField] private int correctNumber;
    
    public bool correct { get; protected set; }

    private void OnCollisionEnter(Collision other)
    {
        TriggerCube cube = other.gameObject.GetComponent<TriggerCube>();
        if (cube && cube.number == correctNumber)
            correct = true;
    }
    
    private void OnCollisionExit(Collision other)
    {
        TriggerCube cube = other.gameObject.GetComponent<TriggerCube>();
        if (cube && cube.number == correctNumber)
            correct = false;
    }
}
