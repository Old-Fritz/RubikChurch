using UnityEngine;

namespace Scene2
{
    public class TriggerCube : MonoBehaviour
    {
        [SerializeField] private float correctNumber;
    
        public float number
        {
            get { return correctNumber; }
        }
    }
}
