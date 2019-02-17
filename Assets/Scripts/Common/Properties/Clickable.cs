﻿using UnityEngine;
using UnityEngine.Events;

namespace Common.Properties
{
    public class Clickable : MonoBehaviour
    {

        [SerializeField] private UnityEvent onClick;
        [SerializeField] private float distance = 2;

        public void click()
        {
            onClick.Invoke();
        }

        public float getDist()
        {
            return distance;
        }
    }
}
