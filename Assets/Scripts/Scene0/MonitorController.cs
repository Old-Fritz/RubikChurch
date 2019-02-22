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
        [SerializeField] private SceneCur scene;
    
        public void openBrowser()
        {
            if (!scene.cubeUp)
                return;
        
            mainScreen.SetActive(false);
            browserSearch.SetActive(true);
        }

        public void searchBack()
        {
            mainScreen.SetActive(true);
            browserSearch.SetActive(false);
        }

        public void doSearch()
        {
            browserSearch.SetActive(false);
            browserPage.SetActive(true);
        }

        public void closeBrowser()
        {
            mainScreen.SetActive(true);
            browserPage.SetActive(false);
        }
    

        public void openAlert()
        {
            blAlert.SetActive(true);
        }

        public void closeAlert()
        {
            blAlert.SetActive(false);
        }

        public void openBL()
        {
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
            mainScreen.SetActive(true);
            blGame.SetActive(false);
        
            // clear save
            Save save = getBLSave();
            if(save)
                save.clear();
        }

        public void makeChoise()
        {
            mainScreen.SetActive(true);
            blGame.SetActive(false);
        }

        public void clickIcon(int ind)
        {
            // change icon's color
            if (icons.transform.childCount > ind)
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
