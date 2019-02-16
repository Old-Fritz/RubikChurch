using UnityEngine;

namespace Common.Properties
{
    public class Draggable : MonoBehaviour
    {
        [SerializeField] private float startDistance;
        [SerializeField] private float workDistance;

        private Transform oldParent;
    
        public void startDrag()
        {
            oldParent = transform.parent;
            Rigidbody rigid = GetComponent<Rigidbody>();
            if (rigid)
                rigid.useGravity = false;

            Collider collider = GetComponent<Collider>();
            if (collider)
                collider.enabled = false;
        }

        public void endDrag()
        {
            transform.parent = oldParent;
            Rigidbody rigid = GetComponent<Rigidbody>();
            if (rigid)
                rigid.useGravity = true;
        
            Collider collider = GetComponent<Collider>();
            if (collider)
                collider.enabled = true;
        }

        public void push(Vector3 direction)
        {
            Rigidbody rigid = GetComponent<Rigidbody>();
            if(rigid)
                rigid.AddForce(direction);
        }

        public float getStartDist()
        {
            return startDistance;
        }

        public float getWorkDist()
        {
            return workDistance;
        }
    }
}
