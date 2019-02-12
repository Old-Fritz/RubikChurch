using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorController : MonoBehaviour
{
    [SerializeField] private GameObject mainScreen;
    [SerializeField] private GameObject browserSearch;
    [SerializeField] private GameObject browserPage;
    [SerializeField] private GameObject blAlert;
    [SerializeField] private GameObject blGame;
    
    
    public void openBrowser()
    {
        mainScreen.SetActive(false);
        browserSearch.SetActive(true);
    }
}
