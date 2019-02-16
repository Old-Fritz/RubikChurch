using UnityEngine;

namespace Common.Managers
{
    public class GameManager : MonoBehaviour
    {
        private bool onStart = true;
    
        void Start()
        {   
            Scenes.Init();
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
                // go to start scene
                Scenes.loadScene(0);
                Scenes.goToScene(0);
                //Scenes.loadScene(2);
                onStart = false;
            }
        }
    }
}
