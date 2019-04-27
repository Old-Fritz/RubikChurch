using System;
using Common.Managers;
using Common.PlayerComps;
using Common.Properties;
using UnityEngine;

namespace Scene0
{
    public class Table : MonoBehaviour
    {
        [SerializeField] private SceneCur scene;
        [SerializeField] private String unReadyText;
    
        public void onClick()
        {
            if (!scene.cubeUp)
                Interface.main.showSubtitles(unReadyText, 3);
            else
            {
                // move accepted in scene1
                Move playerMove = Player.main.GetComponent<Move>();
                if (playerMove)
                    playerMove.moveAccepted = true;

                Transitor transitor = GetComponent<Transitor>();
                if(transitor)
                    transitor.transite();
            }
        }
    }
}
