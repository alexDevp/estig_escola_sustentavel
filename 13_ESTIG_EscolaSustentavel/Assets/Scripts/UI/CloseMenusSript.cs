using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenusSript : MonoBehaviour
{
    private Game _game;
    public GameObject implementationMenu;
    public GameObject menu;

    private void Start()
    {
        _game = GameObject.FindGameObjectWithTag("UiCanvas").GetComponent<Game>();
    }

    public void CloseSensor()
    {
        if (_game.PickedSensors != 0)
        {
            SetInactive();
        }
    }
    
    public void CloseLamp()
    {
        if (_game.PickedLamps != 0)
        {
            SetInactive();
        }
    }
    
    public void ClosePanel()
    {
        if (_game.PickedPanels != 0)
        {
            SetInactive();
        }
    }

    private void SetInactive()
    {
        implementationMenu.SetActive(false);
        menu.SetActive(false);
        GameObject.FindGameObjectWithTag("UiCanvas").GetComponent<ImplementacoesMenu>().CloseMenu();
    }
}
