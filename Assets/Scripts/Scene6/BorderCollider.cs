using Common.PlayerComps;
using Common.Properties;
using UnityEngine;

namespace Scene6
{
    public class BorderCollider : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Player player = other.gameObject.GetComponent<Player>();

            if (player)
            {
                // transite to scene 8 in enter
                Transitor transitor = GetComponent<Transitor>();
                if(transitor)
                    transitor.transite();
            }
        }
    }
}
