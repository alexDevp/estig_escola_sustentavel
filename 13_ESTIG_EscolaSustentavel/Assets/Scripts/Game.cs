using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Timers;
using Database;
using Database.Model;
using Mono.Data.Sqlite;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    private const double _khwprice = 0.14256;
    private string _name = "";
    private int _budget = 65000;
    private int _score = 0;
    private int _pickedLamps = 0;
    private int _pickedPanels = 0;
    private int _pickedSensors = 0;
    private int _timepassed = 0;
    public DatabaseManager databaseManager;
    private GameObject _parkingSolarPanels;
    private GameObject _roofSolarPanels;

    public string Name => _name;

    public int Budget => _budget;

    public int Score => _score;

    public int PickedLamps => _pickedLamps;

    public int PickedPanels => _pickedPanels;

    public int PickedSensors => _pickedSensors;

    public int Timepassed => _timepassed;

    public Text scoreUntilNow;
    public Text cashRemaining;
    
    //Lamps
    public Text energyBeforeLamps;
    public Text energyAfterLamps;
    public Text savingsEnergyLamps;
    public Text savingsPriceLamps;
    public Text lamp1Quantity;
    public Text lamp2Quantity;
    public Text lamp3Quantity;
    public Text lamp1Price;
    public Text lamp2Price;
    public Text lamp3Price;
    
    //Panels
    public Text panel1Quantity;
    public Text panel2Quantity;
    public Text panel3Quantity;
    public Text panel1Price;
    public Text panel2Price;
    public Text panel3Price;
    public Text panelEnergyProduction;
    public Text panelSavingsMoney;
    
    //PickedSensors
    public Text sensor1Quantity;
    public Text sensor2Quantity;
    public Text sensor1Price;
    public Text sensor2Price;
    public Text sensorsEnergyBefore;
    public Text sensorsEnergyAfter;
    public Text sensorsSavingsEnergy;
    public Text sensorsSavingsMoney;
    
    private void Start()
    {
        SetupPrefabs();
        HidePrefabs();

        databaseManager = gameObject.AddComponent<DatabaseManager>();
        var timer = new System.Timers.Timer(1000);
        timer.Elapsed += HandleTimerElapsed;
        timer.Enabled = true;
        cashRemaining.text = _budget + " €";
        scoreUntilNow.text = _score + " Pts";
    }
    
    public void LoadLamps()
    {
        //Lamps Load
        energyBeforeLamps.text = "0 kWh";
        energyAfterLamps.text = "0 kWh";;
        savingsEnergyLamps.text = "0 kWh";
        savingsPriceLamps.text = "0 €" ;
        
        Lamp lamp1 = databaseManager.GetLamps(1);
        lamp1Quantity.text = lamp1.UnitCount.ToString();
        lamp1Price.text = Math.Round((lamp1.UnitPrice * lamp1.UnitCount), 2) + "€";
        
        Lamp lamp2 = databaseManager.GetLamps(2);
        lamp2Quantity.text = lamp2.UnitCount.ToString();
        lamp2Price.text = Math.Round((lamp2.UnitPrice* lamp2.UnitCount), 2) + "€";
        
        Lamp lamp3 = databaseManager.GetLamps(3);
        lamp3Quantity.text = lamp3.UnitCount.ToString();
        lamp3Price.text = Math.Round((lamp3.UnitPrice* lamp3.UnitCount), 2) + "€";
    }

    public void LoadPanels()
    {
        panelEnergyProduction.text = "0 kWh";
        panelSavingsMoney.text = "0 €";  
        Panel panel1 = databaseManager.GetPanels(1);
        panel1Quantity.text = panel1.UnitCount.ToString();
        double totalPanel1 = panel1.UnitPrice * panel1.UnitCount;
        panel1Price.text = Math.Round((totalPanel1), 2) + "€";
        
        Panel panel2 = databaseManager.GetPanels(2);
        panel2Quantity.text = panel2.UnitCount.ToString();
        double totalPanel2 = panel2.UnitPrice * panel2.UnitCount;
        panel2Price.text = Math.Round((totalPanel2), 2) + "€";
        
        Panel panel3 = databaseManager.GetPanels(3);
        panel3Quantity.text = panel3.UnitCount.ToString();
        panel3Price.text = Math.Round((totalPanel1 + totalPanel2), 2) + "€";
    }

    public void LoadSensors()
    {
        sensorsEnergyBefore.text = "0 kWh";
        sensorsEnergyAfter.text = "0 kWh";
        sensorsSavingsEnergy.text = "0 kWh";
        sensorsSavingsMoney.text = "0 €";
        Sensor sensor1 = databaseManager.GetSensors(1);
        sensor1Quantity.text = sensor1.UnitCount.ToString();
        sensor1Price.text = Math.Round((sensor1.UnitPrice * sensor1.UnitCount), 2) + "€";
        Sensor sensor2 = databaseManager.GetSensors(2);
        sensor2Quantity.text = sensor2.UnitCount.ToString();
        sensor2Price.text = Math.Round((sensor2.UnitPrice * sensor2.UnitCount), 2) + "€";
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
        panelEnergyProduction.text = (panel.EnergyBefore - panel.EnergyAfter) + " kWh";
        panelSavingsMoney.text = Math.Round(((panel.EnergyBefore - panel.EnergyAfter) * _khwprice), 2) + " €";
        print(panel.Name);
        
    }

    //*****Lampadas*****//
    //Seleciona a opção de implementação das Lampadas
    public void OptionLamp(int option)
    {
        _pickedLamps = option;
        Lamp lamps = databaseManager.GetLamps(_pickedLamps);
        energyBeforeLamps.text = (lamps.EnergyBefore) + " kWh";
        energyAfterLamps.text = (lamps.EnergyAfter) + " kWh";
        savingsEnergyLamps.text = (lamps.EnergyBefore - lamps.EnergyAfter) + " kWh";
        savingsPriceLamps.text = Math.Round(((lamps.EnergyBefore - lamps.EnergyAfter) * _khwprice), 2) + " €" ;
        print(lamps.Name);
        
    }

    //*****Sensores*****//
    //Seleciona a opção de implementação 1 dos paineis solares
    public void OptionSensors(int option)
    {
        _pickedSensors = option;
        Sensor sensor = databaseManager.GetSensors(_pickedSensors);
        sensorsEnergyBefore.text = sensor.EnergyBefore + " kWh";
        sensorsEnergyAfter.text = sensor.EnergyAfter + " kWh";
        sensorsSavingsEnergy.text = (sensor.EnergyBefore - sensor.EnergyAfter) + " kWh";
        sensorsSavingsMoney.text = Math.Round(((sensor.EnergyBefore - sensor.EnergyAfter) * _khwprice), 2) + " €";
        print(sensor.Name);
    }

    
    //******Confirmar Implementações******//
    /**
     * Confirmar a opção das lâmpadas
     */
    public void ConfirmLamps()
    {
        
    }
    
    /**
     * Confirmar a opção das painéis
     */
    public void ConfirmPanels()
    {
        
    }
    
    /**
     * Confirmar a opção das sensores
     */
    public void ConfirmSensors()
    {
        
    }
    
    //******Cancelar Implementações******//
    /**
     * Cancelar a opção das lâmpadas
     */
    public void CancelLamps()
    {
        _pickedLamps = 0;
    }
    
    /**
     * Cancelar a opção das painéis
     */
    public void CancelPanels()
    {
        _pickedPanels = 0;
    }
    
    /**
     * Cancelar a opção das sensores
     */
    public void CancelSensors()
    {
        _pickedSensors = 0;
    }
    

    //*****Mostrar Implementações*****//

    //*****Paineis*****//

    //Faz aparecer paineis
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

    //Faz aparecer lampadas
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

    //Faz aparecer os sensores
    public void ImplementSensors()
    {
        if (_pickedSensors == 1)
        {
            //TODO Fazer aparecer sem texturas o objeto no(s) sitio(s)
        }
        else if (_pickedSensors == 2)
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

        if (_pickedPanels != 0 && _pickedLamps != 0 && _pickedSensors != 0)
        {
            AcabarJogo();
        }
    }

    //*****Lampadas*****//
    //Constroi as Lampadas
    public void ConstruirLampadas()
    {
        //TODO Ao clicar no local para implementar fazer aparecer as texturas do objeto

        if (_pickedPanels != 0 && _pickedLamps != 0 && _pickedSensors != 0)
        {
            AcabarJogo();
        }
    }

    //*****Sensores*****//
    //Constroi as Lampadas
    public void ConstruirSensores()
    {
        //TODO Ao clicar no local para implementar fazer aparecer as texturas do objeto

        if (_pickedPanels != 0 && _pickedLamps != 0 && _pickedSensors != 0)
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
            _pickedLamps, _pickedPanels, _pickedSensors);
        databaseManager.InsertScoreIntoDB(score);
        //TODO Voltar para o MENU Principal (Trocar a scene para 0)
        _name = "";
        _pickedLamps = 0;
        _pickedPanels = 0;
        _pickedSensors = 0;
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
    
}