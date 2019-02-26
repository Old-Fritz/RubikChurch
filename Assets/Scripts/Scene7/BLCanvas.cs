using System.Collections;
using System.Collections.Generic;
using Common.Managers;
using Common.PlayerComps;
using Common.Properties;
using UnityEngine;

namespace Scene7
{
    public class BLCanvas : MonoBehaviour
    {
        [SerializeField] private float firstPauseTime;
        [SerializeField] private float secondPauseTime;
        [SerializeField] private GameObject noAnimeSprite;
        [SerializeField] private List<GameObject> goodSprites;
        [SerializeField] private List<GameObject> badSprites;


        private void OnEnable()
        {
            Interface.main.setTargetActive(false);
            StartCoroutine(firstPause());
        }

        private void showSprites()
        {
            Save save = Player.main.GetComponent<Save>();
            // get saves
            int ind = 0;
            bool result = false;
            if (save)
            {
                save.getEnding(out ind, out result);
                save.currentEnd = Save.End.BL;
            }
            
            // analize saves and show correct sprites
            // good ending
            if (result)
            {
                // all spites
                if (ind == 0)
                {
                    foreach (GameObject obj in goodSprites)
                    {
                        obj.SetActive(true);
                    }
                }
                // good ending
                else
                {
                    goodSprites[ind - 1].SetActive(true);
                }
            }
            else
            {
                // no spites
                if (ind == 0)
                {
                    noAnimeSprite.SetActive(true);
                    Interface.main.showSubtitles("Пустота...");
                }
                // bad ending
                else
                {
                    badSprites[ind - 1].SetActive(true);
                }
            }
        }

        private IEnumerator firstPause()
        {
            yield return new WaitForSeconds(firstPauseTime);
            showSprites();
            StartCoroutine(secondPause());
        }
    
        private IEnumerator secondPause()
        {
            yield return new WaitForSeconds(secondPauseTime);
            // transit after pause
            Transitor transitor = GetComponent<Transitor>();
            if(transitor)
                transitor.transite();
        }
    
    
    }
}
