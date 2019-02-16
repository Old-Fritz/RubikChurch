using UnityEngine;

namespace Scene0
{
    public class HomeNote : MonoBehaviour
    {
        [SerializeField] private GameObject movedPosition;
    
    
        private bool moved;
    
    
        public void onClick()
        {
            if (!moved)
            {
                transform.position = movedPosition.transform.position;
                moved = true;
            }
        }
    }
}
