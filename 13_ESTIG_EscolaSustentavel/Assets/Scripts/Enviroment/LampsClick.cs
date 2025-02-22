﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampsClick : MonoBehaviour
{
    public GameObject lamp;

    private Game _game;
    private bool _isGameNotNull;
    private bool didImplement = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _game = GameObject.FindGameObjectWithTag("UiCanvas").GetComponent<Game>();
        _isGameNotNull = _game != null;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, 6))
        {
            
            if (Input.GetKeyDown(KeyCode.E) && hit.collider.tag.Equals(lamp.tag))
            {
                if (_isGameNotNull && !didImplement && _game.ConfirmedLamps)
                {
                    _game.ImplementLamps();
                    didImplement = true;
                }
            }
        }
    }
}