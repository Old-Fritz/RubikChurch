using Common.PlayerComps;
using UnityEngine;

namespace Common.Properties
{
    public class Transitor : MonoBehaviour
    {
        [SerializeField] private float forwardTime;
        [SerializeField] private float backTime;
        [SerializeField] private int scene;

        public void transite()
        {
            Transition transition = Player.main.gameObject.GetComponent<Transition>();
            if(transition)
                transition.startTransition(forwardTime, backTime, scene);
        }
    }
}
