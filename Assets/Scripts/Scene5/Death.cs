using System;
using System.Collections;
using System.Collections.Generic;
using Common.Managers;
using Common.PlayerComps;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private float deathTime;
    [SerializeField] private String deathHint;

    private bool waitingDeath, waited;

    // Update is called once per frame
    void Update()
    {
        // Die on press
        if (waitingDeath)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                // start final
                Finaling final = Player.main.gameObject.GetComponent<Finaling>();
                if(final)
                    final.startFinal(deathTime, Finaling.End.Bad);
                waitingDeath = false;
                waited = true;
            }
        }
    }

    public void waitDeath()
    {
        if (!waited)
        {
            waitingDeath = true;
            Interface.main.showSubtitles(deathHint,1488);
        }
    }
}
