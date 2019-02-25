using System;
using Common.Managers;
using UnityEngine;
using UnityEngine.Events;

namespace Common.Properties
{
    public class Selectable : MonoBehaviour
    {
        [SerializeField] private String descriptionText;
        [SerializeField] private float distance = 2;

        private bool selected = false;

        public void select()
        {
            Interface.main.changeDescription(descriptionText);
            selected = true;
        }

        public void unSelect()
        {
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
