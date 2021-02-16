﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofPanelClick : MonoBehaviour
{
    private GameObject _electricalSwitchboard;

    private Game _game;
    private bool _isGameNotNull;
    
    // Start is called before the first frame update
    void Start()
    {
        _electricalSwitchboard = GameObject.FindGameObjectWithTag("ActivateRoofPanel");
        _game = GameObject.FindGameObjectWithTag("UiCanvas").GetComponent<Game>();
        _isGameNotNull = _game != null;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, 3))
        {
            if (Input.GetKeyDown(KeyCode.E) && hit.collider.tag.Equals(_electricalSwitchboard.tag))
            {
                if (_isGameNotNull)
                {
                    _game.ImplementPanels(2);
                }
            }
        }
    }

    private void FixedUpdate()
    {
    }
}