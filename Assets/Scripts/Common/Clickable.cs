using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Clickable : MonoBehaviour
{

    [SerializeField] private UnityEvent onClick;

    public void click()
    {
        onClick.Invoke();
    }
}
