using Common.PlayerComps;
using UnityEngine;

namespace Scene6
{
    public class DeathCollider : MonoBehaviour
    {    
        private void OnTriggerEnter(Collider other)
        {
            Player player = other.gameObject.GetComponent<Player>();
        
            if(player)
                DeathEffect.startDeath();
        }

        private void OnTriggerExit(Collider other)
        {
            Player player = other.gameObject.GetComponent<Player>();

            if (player)
                DeathEffect.endDeath();
        }
    }
}
