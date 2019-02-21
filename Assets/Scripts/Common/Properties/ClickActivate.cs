using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickActivate : MonoBehaviour
{
    [SerializeField] private GameObject obj;

    public void onClick()
    {
        obj.SetActive(!obj.activeInHierarchy);
    }
}
