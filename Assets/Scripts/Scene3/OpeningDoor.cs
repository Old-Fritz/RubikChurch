using System;
using Common.Managers;
using UnityEngine;

namespace Scene3
{
    public class OpeningDoor : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private String doorLockedSubs;
        [SerializeField] private SceneCur scene;

        private bool moving, opened;
        private Quaternion target;
    
        void Update()
        {
            if (moving)
            {
                transform.localRotation = Quaternion.RotateTowards(transform.localRotation, target, speed*Time.deltaTime);
                if (transform.localRotation == target)
                {
                    moving = false;
                    opened = !opened;
                    
                    // enable collider back
                    Collider collider = GetComponent<Collider>();
                    if (collider)
                        collider.enabled = true;
                }
            }
        }

        public void onClick()
        {
            if (!scene.keyUp)
            {
                Interface.main.showSubtitles(doorLockedSubs, 3);
            }
            else if (!moving)
            {
                float angle = 90;
                if (opened)
                    angle = -90;
            
                target = transform.localRotation*Quaternion.AngleAxis(angle, Vector3.forward);
                moving = true;
            }
        }
    }
}
