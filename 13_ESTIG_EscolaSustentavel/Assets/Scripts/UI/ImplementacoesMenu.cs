using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImplementacoesMenu : MonoBehaviour
{
    public static bool menuIsOpen = false;

    public GameObject implementationsMenuUI;
    
    public GameObject lampsMenu;
    public GameObject sensorsMenu;
    public GameObject panelsMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(menuIsOpen)
            {
                lampsMenu.SetActive(false);
                sensorsMenu.SetActive(false);
                panelsMenu.SetActive(false);
                CloseMenu();
            }
            else
            {
                OpenMenu();
            }
        }
    }

    public void CloseMenu()
    {
        implementationsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        menuIsOpen = false;
    }

    void OpenMenu()
    {
        implementationsMenuUI.SetActive(true);
        Time.timeScale = 0f;
        menuIsOpen = true;
    }

    public void Sair()
    {
        Application.Quit();
    }
}
