using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameClick : MonoBehaviour
{
    public GameObject endStructure;

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
            if (Input.GetKeyDown(KeyCode.E) && hit.collider.tag.Equals(endStructure.tag))
            {
                if (_isGameNotNull && !_didImplement && _game.PickedLamps != 0 && _game.PickedPanels != 0 && _game.PickedSensors != 0)
                {
                    _game.EndGame();
                    _didImplement = true;
                }
            }
        }
    }
}
