using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCube : MonoBehaviour
{
    [SerializeField] private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        source.Play();
    }
}
