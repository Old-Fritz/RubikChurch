using Common.PlayerComps;
using UnityEngine;

namespace Common.Managers
{
    public class GameManager : MonoBehaviour
    {
        private bool onStart = true;
    
        void Start()
        {   
            Scenes.Init();
            Random.InitState((int)System.DateTime.Now.Ticks);
        }

        void Update()
        {
            if(onStart)
                processStartInput();
        }

        private void processStartInput()
        {
            if (Input.GetMouseButtonUp(0))
            {
                // move accepted in scene1
                Move playerMove = Player.main.GetComponent<Move>();
                if (playerMove)
                    playerMove.moveAccepted = true;
                
                // go to start scene
                Scenes.loadScene(8);
                Scenes.goToScene(8);
                //Scenes.loadScene(2);
                onStart = false;
            }
        }
    }
}
