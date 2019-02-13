using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Selectable : MonoBehaviour
{
    [SerializeField] private UnityEvent onSelect;
    [SerializeField] private UnityEvent onUnSelect;
    [SerializeField] private String subtitlesText;

    public void select()
    {
        onSelect.Invoke();
        changeSubtitles(subtitlesText);
    }

    public void unSelect()
    {
        onUnSelect.Invoke();
        changeSubtitles("");
    }

    private void changeSubtitles(String text)
    {
        GameObject mainInterface = GameObject.FindGameObjectWithTag("Interface");

        if (mainInterface)
        {
            Interface interfaceComp = mainInterface.GetComponent<Interface>();
            if(interfaceComp)
                interfaceComp.changeSubtitles(text);
        }
        
    }
}
