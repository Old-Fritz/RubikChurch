using UnityEngine;

namespace Scene4
{
    public class MovingCube : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Vector3 maxRotation;
        [SerializeField] private Vector3 minRotation;

        private Quaternion target;

        void Start()
        {
            generateRotation();
        }

        void Update()
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, target, Time.deltaTime * speed);
            if(transform.localRotation == target)
                generateRotation();
        }
    
        private void generateRotation()
        {
            Vector3 newRotation;

            newRotation.x = Random.Range(minRotation.x, maxRotation.x);
            newRotation.y = Random.Range(minRotation.y, maxRotation.y);
            newRotation.z = Random.Range(minRotation.z, maxRotation.z);
        
            target = Quaternion.Euler(newRotation);
        }
    }
}
