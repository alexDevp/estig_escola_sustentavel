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
    
    public void Jogar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ShowScores()
    {
        
        _databaseManager = gameObject.AddComponent<DatabaseManager>();
        List<Score> scores = _databaseManager.GetScores();
        
        for (int i = 0; i < scores.Count; i++)
        {
            GameObject tmpObject = Instantiate(scorePrefab);
            Score tmpScore = scores[i];
            tmpObject.GetComponent<ScoreScript>().SetScore(tmpScore.Username, tmpScore.ScoreValue.ToString(), tmpScore.Timepassed.ToString());
            
            tmpObject.transform.SetParent(scoreParent);
        }
    }
    
    public void Sair()
    {
        Application.Quit();
    }
}