using Common.PlayerComps;
using UnityEngine;

namespace Scene6
{
    public class DeathCollider : MonoBehaviour
    {    
        private void OnCollisionEnter(Collision other)
        {
            Player player = other.gameObject.GetComponent<Player>();
        
            if(player)
                DeathEffect.startDeath();
        }

        private void OnCollisionExit(Collision other)
        {
            Player player = other.gameObject.GetComponent<Player>();

            if (player)
                DeathEffect.endDeath();
        }
    }
}
