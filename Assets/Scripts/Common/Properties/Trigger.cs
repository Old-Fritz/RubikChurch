using Common.PlayerComps;
using UnityEngine;
using UnityEngine.Events;

namespace Common.Properties
{
    public class Trigger : MonoBehaviour
    {
        [SerializeField] private bool playerTrigger;
        [SerializeField] private UnityEvent onEnter;
        [SerializeField] private UnityEvent onExit;
        
        private void OnTriggerEnter(Collider other)
        {
            if (checkPayer(other))
                onEnter.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            if (checkPayer(other))
                onExit.Invoke();
        }

        private bool checkPayer(Collider other)
        {
            // trigger only for player if on
            if (!playerTrigger)
                return true;

            Player player = other.gameObject.GetComponent<Player>();
            if (player)
                return true;
            
            return false;
        }
    }
}