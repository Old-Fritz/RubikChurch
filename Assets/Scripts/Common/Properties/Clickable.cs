using System;
using UnityEngine;
using UnityEngine.Events;

namespace Common.Properties
{
    public class Clickable : MonoBehaviour
    {
        public enum ClickType
        {
            Base, Pray, Respect
        }
        
        [SerializeField] private UnityEvent onClick;
        [SerializeField] private float distance = 2;
        [SerializeField] private ClickType type = ClickType.Base;
        

        public void click()
        {
            onClick.Invoke();
        }

        public float getDist()
        {
            return distance;
        }

        public ClickType getClickType()
        {
            return type;
        }
    }
}
