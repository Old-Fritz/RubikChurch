using Common.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Common.PlayerComps
{
    public class Finaling : MonoBehaviour
    {
        public enum End
        {
            BL, Good, Bad
        }
        
        [SerializeField] private Image blackScreen;

        private float deltaTime;
        private bool ending;

        void Update()
        {
            // make screen darker
            if (ending)
            {
                blackScreen.color = new Color(0, 0, 0, blackScreen.color.a + Time.deltaTime * deltaTime);
                if(blackScreen.color.a>=1)
                    goToFinal();
            }
        }

        public void startFinal(float blackTime, End end)
        {
            deltaTime = 1 / blackTime;
            blackScreen.color = new Color(0,0,0,0);
            ending = true;
            // save end
            Save save = GetComponent<Save>();
            if (save)
                save.currentEnd = end;
        }
        
        private void goToFinal()
        {
            ending = false;
            Scenes.loadScene(9);
            Scenes.goToScene(9);
            Scenes.unLoadScene(Scenes.currentScene);
        }
    }   
}