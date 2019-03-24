using System.Collections;
using System.Collections.Generic;
using Common.Properties;
using Cube;
using UnityEngine;

namespace Scene4
{
    public class OutDoor : MonoBehaviour
    {
        [SerializeField] private RubikCube cube;

        private bool moved;
        private AudioSource source;
        
        void Start()
        {
            source = GetComponent<AudioSource>();
        }

        void Update()
        {
            if (!moved && cube.checkCorrect())
            {
                ClickMovable move = GetComponent<ClickMovable>();
                if (move)
                {
                    move.move();
                    moved = true;
                    source.Play();
                }
            }
        }
    }
}