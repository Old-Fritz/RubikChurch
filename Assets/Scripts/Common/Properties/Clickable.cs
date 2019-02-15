using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Clickable : MonoBehaviour
{

    [SerializeField] private UnityEvent onClick;
    [SerializeField] private float distance;

    public void click()
    {
        onClick.Invoke();
    }

    public float getDist()
    {
        return distance;
    }
}
