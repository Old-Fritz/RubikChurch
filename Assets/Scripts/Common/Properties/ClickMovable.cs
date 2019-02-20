using UnityEngine;

namespace Common.Properties
{
    public class ClickMovable : MonoBehaviour
    {
    
        [SerializeField] private float speed = 1;
        [SerializeField] private Vector3 direction;
        
        private bool moving, moved;
        private Vector3 targetPos;

        void Update()
        {
            if (moving && !moved)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
                if (transform.position == targetPos)
                {
                    moving = false;
                    moved = true;
                }
            }
        }

        public void move()
        {
            if (!moving && !moved)
            {
                moving = true;
            
                // set target pos
                targetPos = transform.position + direction;
            }
        }
    }
}
