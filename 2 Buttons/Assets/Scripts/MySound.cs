using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySound : MonoBehaviour {

    AudioSource audioSrc;

    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void Play()
    {
        GetComponent<AudioSource>().Play();
        Destroy(gameObject, audioSrc.clip.length);
    }
}
