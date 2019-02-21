using System;
using System.Collections;
using Common.Managers;
using Common.Properties;
using UnityEngine;

namespace Common.PlayerComps
{
    public class GoldenCube : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float showTime;
        [SerializeField] private String hintText;

        private bool clicked;

        void Update()
        {
            if (clicked)
                transform.rotation *= Quaternion.AngleAxis(speed*Time.deltaTime,Vector3.up);
        }
        
        public void pray(GameObject obj, float dist)
        {
            gameObject.SetActive(true);
            StartCoroutine(showCube());
            Clickable click = obj.GetComponent<Clickable>();
            // invoke click if click type is pray
            if (click && click.getDist()>=dist && (click.getClickType() == Clickable.ClickType.Pray))
                click.click();

        }

        public void respect(GameObject obj, float dist)
        {
            gameObject.SetActive(true);
            StartCoroutine(showCube());
            Clickable click = obj.GetComponent<Clickable>();
            // invoke click if click type is respect
            if (click && click.getDist()>=dist && (click.getClickType() == Clickable.ClickType.Respect))
                click.click();
        }

        public void onClick()
        {
            if (!clicked)
            {
                Clicker clicker = Player.main.gameObject.GetComponent<Clicker>();
                if (clicker)
                {
                    // set cube in front of player
                    clicker.setGoldenCube(this);
                    // clear description
                    Selectable select = GetComponent<Selectable>();
                    if(select)
                        select.setDesc("");
                    // show some effects
                    StartCoroutine(showCube());
                    Interface.main.showSubtitles(hintText);
                    clicked = true;
                }
            }
        }
        

        private IEnumerator showCube()
        {
            // show cube on showTime seconds
            yield return new WaitForSeconds(showTime);
            gameObject.SetActive(false);
        }
    }
}
