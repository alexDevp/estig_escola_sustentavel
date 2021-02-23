using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Timers;
using Database;
using Database.Model;
using Mono.Data.Sqlite;
using UI;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private DatabaseManager _databaseManager;
    public GameObject scorePrefab;
    public Transform scoreParent;

    private void Start()
    {
        _databaseManager = gameObject.AddComponent<DatabaseManager>();
    }

    public void Jogar()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowScores()
    {
        List<Score> scores = _databaseManager.GetScores();
        
        for (int i = 0; i < 7 && i < scores.Count; i++)
        {
            GameObject tmpObject = Instantiate(scorePrefab);
            Score tmpScore = scores[i];
            tmpObject.GetComponent<ScoreScript>().SetScore(tmpScore.Username, 
                tmpScore.ScoreValue.ToString(), tmpScore.Timepassed.ToString());
            tmpObject.transform.SetParent(scoreParent);
        }
            
          
    }

    public void Voltar()
    {
       scoreParent.DetachChildren();
    }
    
    public void Sair()
    {
        Application.Quit();
    }
}