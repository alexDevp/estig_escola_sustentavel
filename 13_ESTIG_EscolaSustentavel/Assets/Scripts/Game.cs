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
    private const double Khwprice = 0.14256;
    private string _name = "";
    private double _budget = 65000;
    private int _panels = 0;
    private int _lamps = 0;
    private int _sensors = 0;
    private int _half = 0;
    private int _score = 0;
    private int _pickedLamps = 0;
    private int _pickedPanels = 0;
    private int _pickedSensors = 0;
    private int _timepassed = 0;
    public DatabaseManager databaseManager;
    public GameObject parkingSolarPanels;
    public GameObject roofSolarPanels;
    public GameObject classroomLamps1;
    public GameObject classroomLamps2;
    public GameObject classroomLamps3;
    public GameObject hallSensors1;
    public GameObject hallSensors2;
    
    public string Name => _name;

    public double Budget => _budget;

    public int Score => _score;

    public int PickedLamps => _pickedLamps;

    public int PickedPanels => _pickedPanels;

    public int PickedSensors => _pickedSensors;

    public int Timepassed => _timepassed;

    //General UI
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
    public GameObject textLamps;

    //Panels
    public Text panel1Quantity;
    public Text panel2Quantity;
    public Text panel3Quantity;
    public Text panel1Price;
    public Text panel2Price;
    public Text panel3Price;
    public Text panelEnergyProduction;
    public Text panelSavingsMoney;
    public GameObject textParkingLot;
    public GameObject textRoof;

    //PickedSensors
    public Text sensor1Quantity;
    public Text sensor2Quantity;
    public Text sensor1Price;
    public Text sensor2Price;
    public Text sensorsEnergyBefore;
    public Text sensorsEnergyAfter;
    public Text sensorsSavingsEnergy;
    public Text sensorsSavingsMoney;
    public GameObject textSensors;

    /**
     * Função Start do Projeto
     */
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

    /**
     * Carrega os Valores das Opções das Lampadas na UI
     */
    public void LoadLamps()
    {
        //Lamps Load
        energyBeforeLamps.text = "0 kWh";
        energyAfterLamps.text = "0 kWh";
        ;
        savingsEnergyLamps.text = "0 kWh";
        savingsPriceLamps.text = "0 €";

        Lamp lamp1 = databaseManager.GetLamps(1);
        lamp1Quantity.text = lamp1.UnitCount.ToString();
        lamp1Price.text = Math.Round((lamp1.UnitPrice * lamp1.UnitCount), 2) + "€";

        Lamp lamp2 = databaseManager.GetLamps(2);
        lamp2Quantity.text = lamp2.UnitCount.ToString();
        lamp2Price.text = Math.Round((lamp2.UnitPrice * lamp2.UnitCount), 2) + "€";

        Lamp lamp3 = databaseManager.GetLamps(3);
        lamp3Quantity.text = lamp3.UnitCount.ToString();
        lamp3Price.text = Math.Round((lamp3.UnitPrice * lamp3.UnitCount), 2) + "€";
    }

    /**
     * Carrega os Valores das Opções dos Paineis Solares na UI
     */
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

    /**
     * Carrega os Valores das Opções das Sensores na UI
     */
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
    }

    /**
     * Esconde todos os prefabs das implementações
     */
    private void HidePrefabs()
    {
        parkingSolarPanels.SetActive(false);
        roofSolarPanels.SetActive(false);
        textRoof.SetActive(false);
        textParkingLot.SetActive(false);
        textLamps.SetActive(false);
        classroomLamps1.SetActive(false);
        classroomLamps2.SetActive(false);
        classroomLamps3.SetActive(false);
        hallSensors1.SetActive(false);
        hallSensors2.SetActive(false);

    }

    //*****Botões dos Menus*****//

    //*****Paineis*****//
    //Seleciona a opção de implementação dos paineis solares
    public void OptionPanel(int option)
    {
        _pickedPanels = option;
        Panel panel = databaseManager.GetPanels(_pickedPanels);
        panelEnergyProduction.text = (panel.EnergyBefore - panel.EnergyAfter) + " kWh";
        panelSavingsMoney.text = Math.Round(((panel.EnergyBefore - panel.EnergyAfter) * Khwprice), 2) + " €";
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
        savingsPriceLamps.text = Math.Round(((lamps.EnergyBefore - lamps.EnergyAfter) * Khwprice), 2) + " €";
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
        sensorsSavingsMoney.text = Math.Round(((sensor.EnergyBefore - sensor.EnergyAfter) * Khwprice), 2) + " €";
        print(sensor.Name);
    }
    
    //******Confirmar Implementações******//
    /**
     * Confirmar a opção das lâmpadas
     */
    public void ConfirmLamps()
    {
        if (_pickedLamps != 0)
        {
            Lamp lamp = databaseManager.GetLamps(_pickedLamps);
            _budget = _budget - Math.Round(lamp.UnitPrice * lamp.UnitCount, 2);
            _score = _score + lamp.Points;
            cashRemaining.text = _budget + " €";
            scoreUntilNow.text = _score + " Pts";
        }
        
        if (_pickedLamps == 1 || _pickedLamps == 2 || _pickedLamps == 3)
        {
            textLamps.SetActive(true);
        }
    }

    /**
     * Confirmar a opção das painéis
     */
    public void ConfirmPanels()
    {
        if (_pickedPanels != 0)
        {
            Panel panel = databaseManager.GetPanels(_pickedPanels);
            _budget = _budget - Math.Round(panel.UnitPrice * panel.UnitCount, 2);
            _score = _score + panel.Points;
            cashRemaining.text = _budget + " €";
            scoreUntilNow.text = _score + " Pts";
        }
        
        if (_pickedPanels == 1)
        {
            textParkingLot.SetActive(true);
        }
        else if (_pickedPanels == 2)
        {
            textRoof.SetActive(true);
        }
        else if (_pickedPanels == 3)
        {
            textRoof.SetActive(true);
            textParkingLot.SetActive(true);
        }
    }

    /**
     * Confirmar a opção das sensores
     */
    public void ConfirmSensors()
    {
        if (_pickedSensors != 0)
        {
            Sensor sensor = databaseManager.GetSensors(_pickedSensors);
            _budget = _budget - Math.Round(sensor.UnitPrice * sensor.UnitCount, 2);
            _score = _score + sensor.Points;
            cashRemaining.text = _budget + " €";
            scoreUntilNow.text = _score + " Pts";
        }

        if (_pickedSensors == 1 || _pickedSensors == 2)
        {
            //textSensors.SetActive(true)
        }
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
    //Faz aparecer paineis
    public void ImplementPanels(int panelsType)
    {
        if (_pickedPanels == 1)
        {
            parkingSolarPanels.SetActive(true);
            _panels = 1;
        }
        else if (_pickedPanels == 2)
        {
            roofSolarPanels.SetActive(true);
            _panels = 1;
        }
        else if (_pickedPanels == 3)
        {
            if (panelsType == 1)
            {
                parkingSolarPanels.SetActive(true);
                if (_half == 1)
                {
                    _panels = 1;
                }
                else
                {
                    _half = 1;
                }
            }
            else
            {
                roofSolarPanels.SetActive(true);
                if (_half == 1)
                {
                    _panels = 1;
                }
                else
                {
                    _half = 1;
                }
                
            }
        }
        
        if (_panels == 1 && _lamps == 1 && _sensors == 1)
        {
            AcabarJogo();
        }
    }
    
    //Faz aparecer lampadas
    public void ImplementLamps()
    {
        if (_pickedLamps == 1)
        {
            classroomLamps1.SetActive(true);
            _lamps = 1;
        }
        else if (_pickedLamps == 2)
        {
            classroomLamps2.SetActive(true);
            _lamps = 1;
        }
        else if (_pickedLamps == 3)
        {
            classroomLamps3.SetActive(true);
            _lamps = 1;
        }
        
        if (_panels == 1 && _lamps == 1 && _sensors == 1)
        {
            AcabarJogo();
        }
    }
    
    //Faz aparecer os sensores
    public void ImplementSensors()
    {
        if (_pickedSensors == 1)
        {
            hallSensors1.SetActive(true);
            _sensors = 1;
        }
        else if (_pickedSensors == 2)
        {
            hallSensors2.SetActive(true);
            _sensors = 1;
        }
        
        if (_panels == 1 && _lamps == 1 && _sensors == 1)
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
        _panels = 0;
        _lamps = 0;
        _sensors = 0;
        _half = 0;
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