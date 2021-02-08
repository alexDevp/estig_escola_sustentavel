using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImplementacoesMenu : MonoBehaviour
{
    public static bool MenuIsOpen = false;

    public GameObject ImplementacoesMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(MenuIsOpen)
            {
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
        ImplementacoesMenuUI.SetActive(false);
        Time.timeScale = 1f;
        MenuIsOpen = false;
    }

    void OpenMenu()
    {
        ImplementacoesMenuUI.SetActive(true);
        Time.timeScale = 0f;
        MenuIsOpen = true;
    }

    public void Sair()
    {
        Application.Quit();
    }
}
