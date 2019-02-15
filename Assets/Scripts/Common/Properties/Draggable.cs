using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    [SerializeField] private float startDistance;
    [SerializeField] private float workDistance;

    public void startDrag()
    {
        Rigidbody rigid = GetComponent<Rigidbody>();
        if (rigid)
            rigid.useGravity = false;
    }

    public void endDrag()
    {
        Rigidbody rigid = GetComponent<Rigidbody>();
        if (rigid)
            rigid.useGravity = true;
    }

    public void push(Vector3 direction)
    {
        Rigidbody rigid = GetComponent<Rigidbody>();
        if(rigid)
            rigid.AddForce(direction);
    }

    public float getStartDist()
    {
        return startDistance;
    }

    public float getWorkDist()
    {
        return workDistance;
    }
}
