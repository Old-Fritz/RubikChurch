using Common.Properties;
using UnityEngine;

namespace Scene2
{
    public class Carpet : MonoBehaviour
    {
        [SerializeField] private float speed = 1;
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
        
                // clear select
                Selectable select = GetComponent<Selectable>();
                if(select)
                    select.setDesc("");
            
                // set target pos
                targetPos = transform.position - new Vector3(0, 0, 1);
            }
        }
    }
}
