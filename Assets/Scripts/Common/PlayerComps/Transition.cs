using Common.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Common.PlayerComps
{
    public class Transition : MonoBehaviour
    {  
        [SerializeField] private Image blackScreen;

        private float forwardDeltaTime;
        private float backDeltaTime;
        private bool forward, back;
        private int transScene;

        void Update()
        {
            // make screen darker in forward
            if (forward)
            {
                blackScreen.color = new Color(0, 0, 0, blackScreen.color.a + Time.deltaTime * forwardDeltaTime);
                if (blackScreen.color.a >= 1)
                    transite();
            }
            // make screen lighter in back
            if (back)
            {
                blackScreen.color = new Color(0, 0, 0, blackScreen.color.a - Time.deltaTime * backDeltaTime);
                if (blackScreen.color.a <= 0)
                    back = false;
            }
        }

        public void startTransition(float forwardTime, float backTime, int scene)
        {
            forwardDeltaTime = 1 / forwardTime;
            backDeltaTime = 1 / backTime;
            transScene = scene;
            blackScreen.color = new Color(0,0,0,0);
            
            forward = true;
        }
        
        private void transite()
        {
            forward = false;
            back = true;
            Scenes.goToScene(transScene);
        }
    }   
}