using System.Security.Permissions;
using UnityEngine;

namespace Common.PlayerComps
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private GameObject flashLight;
        
        public static GameObject main{get;protected set;}

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.E))
                flashLight.SetActive(!flashLight.activeInHierarchy);
        }
    
        void Start()
        {
            main = gameObject;
        }
    }
}
