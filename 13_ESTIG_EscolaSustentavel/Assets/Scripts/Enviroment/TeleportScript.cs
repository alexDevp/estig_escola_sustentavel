using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{

    public Transform teleportTarget;
    public GameObject player;

    public AudioSource sound;
    
    private void OnTriggerEnter(Collider other)
    {
        
        player.SetActive(false);
        other.transform.position = teleportTarget.position;
        player.SetActive(true);
        sound.Play();
    }
       
}