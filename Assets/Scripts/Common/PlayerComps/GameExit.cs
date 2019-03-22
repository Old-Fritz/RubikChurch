using System.Collections;
using System.Collections.Generic;
using Common.Managers;
using Common.PlayerComps;
using UnityEngine;

public class GameExit : MonoBehaviour
{
    [SerializeField] private GameObject gameExitScreen;

    private bool screenShowed;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            processEscape();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            processSpace();
        }
        
    }

    private void processEscape()
    {
        if (screenShowed)
        {
            gameExitScreen.SetActive(false);
            screenShowed = false;
        }
        else if (!Interface.main.notesShowed)
        {
            gameExitScreen.SetActive(true);
            screenShowed = true;
        }
    }

    private void processSpace()
    {
        if(screenShowed)
            Application.Quit();
    }
}