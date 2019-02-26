using Common.PlayerComps;
using Common.Properties;
using UnityEngine;

namespace Scene6
{
    public class StartCoridor : MonoBehaviour
    {
        [SerializeField] private float distance;
    
        private bool moved;

        // Update is called once per frame
        void Update()
        {
            if (!moved)
            {
                Vector3 playerPos = Player.main.transform.position;
                if (Vector3.Distance(playerPos, transform.position) > distance)
                {
                    ClickMovable move = GetComponent<ClickMovable>();
                    if(move)
                        move.move();
                
                    moved = true;
                }
            }
        }
    }
}
