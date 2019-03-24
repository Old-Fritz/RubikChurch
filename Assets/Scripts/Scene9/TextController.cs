using System;
using System.Collections.Generic;
using System.Text;
using Common.Managers;
using Common.PlayerComps;
using UnityEngine;
using UnityEngine.UI;

namespace Scene9
{
    public class TextController : MonoBehaviour
    {
        [SerializeField] private Text text;
        [SerializeField] private GameObject titles;
        [SerializeField] private String badEnding;
        [SerializeField] private String goodEnding;
        [SerializeField] private List<String> BLGood;
        [SerializeField] private List<String> BLBad;
        [SerializeField] private AudioClip endSound;

        private bool textShowed;
        
        void Start()
        {
            setText();
        }

        void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                // show titles
                if (!textShowed)
                {
                    text.text = "";
                    titles.gameObject.SetActive(true);
                    textShowed = true;
                }
                // go to start after titles
                else
                {
                    Scenes.loadMain();
                }
            }
        }
        
        private void setText()
        {
            // get save
            Save save = Player.main.GetComponent<Save>();
            Save.End end = Save.End.GOOD;
            if (save)
                end = save.currentEnd;

            // select text from current end
            switch (end)
            {
                case Save.End.BAD:
                    text.text = badEnding;
                    Music.set(endSound);
                    break;
                case Save.End.GOOD:
                    text.text = goodEnding;
                    break;
                case Save.End.BL:
                    if(save)
                        setBLText(save);
                    break;
            }
        }

        private void setBLText(Save save)
        {
            int ind;
            bool result;
            save.getEnding(out ind, out result);

            if (result)
                text.text = BLGood[ind];
            else
                text.text = BLBad[ind];

        }
    }
}
