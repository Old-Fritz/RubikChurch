using System;
using System.Collections;
using System.Collections.Generic;
using Common.Managers;
using Common.Properties;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private String afterKnockSubsText;
    [SerializeField] private String afterKnockDescText;

    private bool knock = false;
    
    public void onClick()
    {
        if (!knock)
            makeKnock();
        else
        {
            comeIn();
        }
    }

    private void makeKnock()
    {
        // change texts
        Interface.main.showSubtitles(afterKnockSubsText, 3);

        Selectable select = gameObject.GetComponent<Selectable>();
        if (select)
            select.setDesc(afterKnockDescText);

        knock = true;
    }

    private void comeIn()
    {
        Scenes.goToScene(2);
    }
}
