using UnityEngine;

namespace Common.Player
{
    public class Player : MonoBehaviour
    {
        public static GameObject main{get;protected set;}
    
        void Start()
        {
            main = gameObject;
        }
    }
}
