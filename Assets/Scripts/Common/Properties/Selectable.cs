using System;
using Common.Managers;
using UnityEngine;
using UnityEngine.Events;

namespace Common.Properties
{
    public class Selectable : MonoBehaviour
    {
        [SerializeField] private UnityEvent onSelect;
        [SerializeField] private UnityEvent onUnSelect;
        [SerializeField] private String descriptionText;
        [SerializeField] private float distance = 2;

        private bool selected = false;

        public void select()
        {
            onSelect.Invoke();
            Interface.main.changeDescription(descriptionText);
            selected = true;
        }

        public void unSelect()
        {
            onUnSelect.Invoke();
            selected = false;
        }

        public void setDesc(String text)
        {
            descriptionText = text;
            if(selected)
                Interface.main.changeDescription(descriptionText);
        }
    
        public float getDist()
        {
            return distance;
        }
    }
}
