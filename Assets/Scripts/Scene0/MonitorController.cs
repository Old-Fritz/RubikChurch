﻿using System;
using Common.Managers;
using Common.PlayerComps;
using UnityEngine;
using UnityEngine.UI;

namespace Scene0
{
    public class MonitorController : MonoBehaviour
    {
        [SerializeField] private GameObject mainScreen;
        [SerializeField] private GameObject browserSearch;
        [SerializeField] private GameObject browserPage;
        [SerializeField] private GameObject blAlert;
        [SerializeField] private GameObject blGame;
        [SerializeField] private GameObject icons;
        [SerializeField] private String startBrowserText;
        [SerializeField] private SceneCur scene;
        
        private AudioSource click;

        void Start()
        {
            click = GetComponent<AudioSource>();
        }
        
        public void openBrowser()
        {
            click.Play();
            if (!scene.cubeUp)
            {
                Interface.main.showSubtitles(startBrowserText, 3);
                return;
            }
        
            mainScreen.SetActive(false);
            browserSearch.SetActive(true);
        }

        public void searchBack()
        {
            click.Play();
            mainScreen.SetActive(true);
            browserSearch.SetActive(false);
        }

        public void doSearch()
        {
            click.Play();
            browserSearch.SetActive(false);
            browserPage.SetActive(true);
        }

        public void closeBrowser()
        {
            click.Play();
            mainScreen.SetActive(true);
            browserPage.SetActive(false);
        }
    

        public void openAlert()
        {
            click.Play();
            blAlert.SetActive(true);
        }

        public void closeAlert()
        {
            click.Play();
            blAlert.SetActive(false);
        }

        public void openBL()
        {
            click.Play();
            mainScreen.SetActive(false);
            blAlert.SetActive(false);
            blGame.SetActive(true);
        
            // clear save
            Save save = getBLSave();
            if(save)
                save.clear();
        
            // clear icons color
            foreach (Transform iconTransform in icons.transform)
            {
                Image icon = iconTransform.gameObject.GetComponent<Image>();
                if (icon)
                    icon.color = new Vector4(1,1,1,1);
            }
        }

        public void closeBL()
        {
            click.Play();
            mainScreen.SetActive(true);
            blGame.SetActive(false);
        
            // clear save
            Save save = getBLSave();
            if(save)
                save.clear();
        }

        public void makeChoise()
        {
            click.Play();
            mainScreen.SetActive(true);
            blGame.SetActive(false);
        }

        public void clickIcon(int ind)
        {
            click.Play();
            // change icon's color
            if (icons.transform.childCount > ind-1)
            {
                Image icon = icons.transform.GetChild(ind - 1).gameObject.GetComponent<Image>();
                if (icon)
                    icon.color = new Vector4(1, 1, 1, 0.7f);
            }
        
            // add save
            Save save = getBLSave();
            if(save)
                save.makeChoise(ind);
        }

        private Save getBLSave()
        {
            GameObject player = Player.main.gameObject;
            if (player)
                return player.GetComponent<Save>();
            return null;
        }
    }
}
