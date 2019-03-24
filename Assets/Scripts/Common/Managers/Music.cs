using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private static AudioSource source;
    [SerializeField] private AudioClip startSound;


    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.Play();
        source.clip = startSound;
    }

    public static void set(AudioClip soundtrack)
    {
        source.clip = soundtrack;
        source.Play();
    }

    public static void stop()
    {
        source.Stop();
    }
}