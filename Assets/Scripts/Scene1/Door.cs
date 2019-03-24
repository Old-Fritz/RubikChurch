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
    [SerializeField] private AudioClip openSound;

    private AudioSource source;
    private bool knock = false;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

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

        source.Play();
        
        knock = true;
    }

    private void comeIn()
    {
        source.clip = openSound;
        source.Play();
        Scenes.goToScene(2);
    }
}
