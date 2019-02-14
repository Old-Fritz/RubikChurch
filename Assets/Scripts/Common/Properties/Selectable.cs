using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Selectable : MonoBehaviour
{
    [SerializeField] private UnityEvent onSelect;
    [SerializeField] private UnityEvent onUnSelect;
    [SerializeField] private String descriptionText;

    public void select()
    {
        onSelect.Invoke();
        Interface.getI().changeDescription(descriptionText);
    }

    public void unSelect()
    {
        onUnSelect.Invoke();
        Interface.getI().changeDescription("");
    }
}
