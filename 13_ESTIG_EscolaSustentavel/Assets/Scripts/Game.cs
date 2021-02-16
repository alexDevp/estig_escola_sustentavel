using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Database;
using Database.Model;
using Mono.Data.Sqlite;
using UnityEditor;
using UnityEngine;

public class Game : MonoBehaviour
{
    private string _name = "";
    private int _budget = 65000;
    private int _score = 0;
    private int _pickedLamps = 0;
    private int _pickedPanels = 0;
    private int _sensors = 0;
    private int _timepassed = 0;
    public DatabaseManager databaseManager;
    private GameObject _parkingSolarPanels;
    private GameObject _roofSolarPanels;

    public string Name => _name;

    public int Budget => _budget;

    public int Score => _score;

    public int PickedLamps => _pickedLamps;

    public int PickedPanels => _pickedPanels;

    public int Sensors => _sensors;

    public int Timepassed => _timepassed;

    private void Start()
    {
        SetupPrefabs();
        HidePrefabs();

        databaseManager = gameObject.AddComponent<DatabaseManager>();
        var timer = new System.Timers.Timer(1000);
        timer.Elapsed += HandleTimerElapsed;
        timer.Enabled = true;
    }

    /**
     * Faz setup dos prefabs
     */
    private void SetupPrefabs()
    {
        _parkingSolarPanels = GameObject.FindGameObjectWithTag("ParkingLotSolarPanels");
        _roofSolarPanels = GameObject.FindGameObjectWithTag("RoofSolarPanels");
    }

    /**
     * Esconde todos os prefabs das implementações
     */
    private void HidePrefabs()
    {
        _parkingSolarPanels.SetActive(false);
        _roofSolarPanels.SetActive(false);
    }

    //*****Botões dos Menus*****//

    //*****Paineis*****//
    //Seleciona a opção de implementação dos paineis solares
    public void OptionPanel(int option)
    {
        _pickedPanels = option;
        Panel panel = databaseManager.GetPanels(_pickedPanels);
        print(panel.Name);
    }

    //*****Lampadas*****//
    //Seleciona a opção de implementação das Lampadas
    public void OptionLamp(int option)
    {
        _pickedLamps = option;
        Lamp lamps = databaseManager.GetLamps(_pickedLamps);
        print(lamps.Name);
    }

    //*****Sensores*****//
    //Seleciona a opção de implementação 1 dos paineis solares
    public void OptionSensors(int option)
    {
        _sensors = option;
        Sensor sensor = databaseManager.GetSensors(_sensors);
        print(sensor.Name);
    }


    //*****Confirmar Implementações*****//

    //*****Paineis*****//

    //Confirma a opção de paineis selecionada e faz aparecer paineis
    public void ImplementPanels(int panelsType)
    {
        if (_pickedPanels == 1)
        {
            _parkingSolarPanels.SetActive(true);
        }
        else if (_pickedPanels == 2)
        {
            _roofSolarPanels.SetActive(true);
        }
        else if (_pickedPanels == 3)
        {
            if (panelsType == 1)
            {
                _parkingSolarPanels.SetActive(true);
            }
            else
            {
                _roofSolarPanels.SetActive(true);
            }
        }
    }

    //*****Lampadas*****//

    //Confirma a opção de lampadas selecionada e faz aparecer lampadas
    public void ImplementLamps()
    {
        if (_pickedLamps == 1)
        {
            //TODO Fazer aparecer sem texturas o objeto no(s) sitio(s)
        }
        else if (_pickedLamps == 2)
        {
            //TODO Fazer aparecer sem texturas o objeto no(s) sitio(s)
        }
        else if (_pickedLamps == 3)
        {
            //TODO Fazer aparecer sem texturas o objeto no(s) sitio(s)
        }
    }

    //*****Sensores*****//

    //Confirma a opção de sensores selecionada e faz aparecer os sensores
    public void ImplementSensors()
    {
        if (_sensors == 1)
        {
            //TODO Fazer aparecer sem texturas o objeto no(s) sitio(s)
        }
        else if (_sensors == 2)
        {
            //TODO Fazer aparecer sem texturas o objeto no(s) sitio(s)
        }
    }


    //*****Terminar Implementação*****//

    //*****Paineis*****//
    //Constroi os Paineis
    public void ConstruirPainel()
    {
        //TODO Ao clicar no local para implementar fazer aparecer as texturas do objeto

        if (_pickedPanels != 0 && _pickedLamps != 0 && _sensors != 0)
        {
            AcabarJogo();
        }
    }

    //*****Lampadas*****//
    //Constroi as Lampadas
    public void ConstruirLampadas()
    {
        //TODO Ao clicar no local para implementar fazer aparecer as texturas do objeto

        if (_pickedPanels != 0 && _pickedLamps != 0 && _sensors != 0)
        {
            AcabarJogo();
        }
    }

    //*****Sensores*****//
    //Constroi as Lampadas
    public void ConstruirSensores()
    {
        //TODO Ao clicar no local para implementar fazer aparecer as texturas do objeto

        if (_pickedPanels != 0 && _pickedLamps != 0 && _sensors != 0)
        {
            AcabarJogo();
        }
    }


    //Termina o jogo e pede o nome ao jogador enquanto mostra um resumo do que fez
    public void AcabarJogo()
    {
        //TODO Mostrar o resumo ao jogador consoante o que escolheu (Ir buscar á BD consoante os IDS)
        //TODO Pedir o Nome do jogador (Meter Input com texto debaixo)
        //TODO Inserir Tudo na BD (Correr Script para adicionar tudo á tabela)
        Score score = new Score(0, _name, _score, _timepassed, new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(),
            _pickedLamps, _pickedPanels, _sensors);
        databaseManager.InsertScoreIntoDB(score);
        //TODO Voltar para o MENU Principal (Trocar a scene para 0)
        _name = "";
        _pickedLamps = 0;
        _pickedPanels = 0;
        _sensors = 0;
        _timepassed = 0;
    }

    public void coisas()
    {
        print("Hello!");
    }

    public void HandleTimerElapsed(object sender, ElapsedEventArgs e)
    {
        // do whatever it is that you need to do on a timer
        _timepassed++;
    }

    private void Update()
    {
    }
}