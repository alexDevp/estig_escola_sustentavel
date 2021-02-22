using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Text textTimeResume;
    public Text textScoreResume;
    public Text textPanelsResume;
    public Text textLampsResume;
    public Text textSensorsResume;
    
    public Text textPanelsResumeTitle;
    public Text textLampsResumeTitle;
    public Text textSensorsResumeTitle;
    public GameObject endGameCanvas;
    
    public void CloseMenu()
    {
        endGameCanvas.SetActive(false);
        Time.timeScale = 1f;
        
    }

    public void OpenMenu()
    {
        endGameCanvas.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
    }

    public void FillEndGameTexts(int timePassed, int scores, string panelsInfo, string lampsInfo, string sensorsInfo)
    {
        TimeSpan time = TimeSpan.FromSeconds(timePassed);
        
        string str = time.ToString(@"hh\:mm\:ss");

        textTimeResume.text = str;

        textScoreResume.text = scores.ToString();

        textPanelsResume.text = panelsInfo;

        textLampsResume.text = lampsInfo;

        textSensorsResume.text = sensorsInfo;
    }

    /**
     * Used in order to change title colors according
     */
    public void ChangeColors(int pickedPanels, int pickedSensors, int pickedLamps)
    {
        Color colorPanels;
        ColorUtility.TryParseHtmlString("#3CFF00", out colorPanels);
        switch (pickedPanels)
        {
            case 1:
                ColorUtility.TryParseHtmlString("#FFE700", out colorPanels);
                break;
            case 2:
                ColorUtility.TryParseHtmlString("#3CFF00", out colorPanels);
                break;
            case 3:
                ColorUtility.TryParseHtmlString("#FF0015", out colorPanels);
                break;
        }
        
        Color colorLamps;
        ColorUtility.TryParseHtmlString("#3CFF00", out colorLamps);
        switch (pickedLamps)
        {
            case 1:
                ColorUtility.TryParseHtmlString("#FF0015", out colorLamps);
                break;
            case 2:
                ColorUtility.TryParseHtmlString("#FFE700", out colorLamps);
                break;
            case 3:
                ColorUtility.TryParseHtmlString("#3CFF00", out colorLamps);
                break;
        }
        
        Color colorSensors;
        ColorUtility.TryParseHtmlString("#3CFF00", out colorSensors);
        switch (pickedSensors)
        {
            case 1:
                ColorUtility.TryParseHtmlString("#FF0015", out colorSensors);
                break;
            case 2:
                ColorUtility.TryParseHtmlString("#3CFF00", out colorSensors);
                break;
        }
        
        textPanelsResumeTitle.color = colorPanels;
        textLampsResumeTitle.color = colorLamps;
        textSensorsResumeTitle.color = colorSensors;
    }
}