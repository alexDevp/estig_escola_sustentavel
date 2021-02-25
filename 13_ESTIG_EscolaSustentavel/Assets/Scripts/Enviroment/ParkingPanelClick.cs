using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingPanelClick : MonoBehaviour
{
    public GameObject electricalSwitchboard;

    private Game _game;
    private bool _isGameNotNull;
    private bool _didImplement = false;
    
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

        if (Physics.Raycast(transform.position, fwd, out hit, 3))
        {
            if (Input.GetKeyDown(KeyCode.E) && hit.collider.tag.Equals(electricalSwitchboard.tag))
            {
                if (_isGameNotNull && !_didImplement && _game.ConfirmedPanels && (_game.PickedPanels == 1 || _game.PickedPanels == 3))
                {
                    _game.ImplementPanels(1);
                    _didImplement = true;
                }
            }
        }
    }

}