using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEggTrigger : MonoBehaviour
{
    public AudioSource sound;
    public GameObject wall;
    public Material image;
    public Material defaultMaterial;
    private bool _entered = false;

    private void OnTriggerEnter(Collider other)
    {
        _entered = !_entered;
        if (sound.isPlaying && !_entered)
        {
            sound.Stop();
            wall.GetComponent<Renderer>().material = defaultMaterial;
        }
        else if(_entered)
        {
            sound.Play();
            wall.GetComponent<Renderer>().material = image;
        }
    }
}
