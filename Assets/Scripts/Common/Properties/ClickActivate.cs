using UnityEngine;

namespace Common.Properties
{
    public class ClickActivate : MonoBehaviour
    {
        [SerializeField] private GameObject obj;

        public void onClick()
        {
            obj.SetActive(!obj.activeInHierarchy);
        }
    }
}
