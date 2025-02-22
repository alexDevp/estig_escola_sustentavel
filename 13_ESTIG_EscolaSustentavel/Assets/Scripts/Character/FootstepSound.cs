﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    private AudioSource footstep_Sound;

    [SerializeField]
    private AudioClip[] footstep_Clip;

    private CharacterController cc;

    [HideInInspector]
    public float volume_Min, volume_Max;

    private float accumulated_Distance;

    [HideInInspector]
    public float step_Distance;

    void Awake()
    {
        footstep_Sound = GetComponent<AudioSource>();

        cc = GetComponentInParent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckToPlayFootstepSound();
    }

    void CheckToPlayFootstepSound()
    {
        if (!cc.isGrounded)
            return;

        if(cc.velocity.sqrMagnitude > 0)
        {
            accumulated_Distance += Time.deltaTime;

            if(accumulated_Distance > step_Distance)
            {
                footstep_Sound.volume = Random.Range(volume_Min, volume_Max);
                footstep_Sound.clip = footstep_Clip[Random.Range(0, footstep_Clip.Length)];
                footstep_Sound.Play();

                accumulated_Distance = 0f;
            }
            else
            {
                accumulated_Distance = 0f;
            }
        }
    }
}
