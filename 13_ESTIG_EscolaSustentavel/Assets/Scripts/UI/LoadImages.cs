using System.Collections;
using System.Collections.Generic;
using Database;
using UnityEngine;

public class LoadImages : MonoBehaviour
{
    private DatabaseManager _databaseManager;

    // Start is called before the first frame update
    void Start()
    {
        _databaseManager = GameObject.FindGameObjectWithTag("UiCanvas").GetComponent<Game>().databaseManager;
    }

    private void LoadImagesPanels()
    {
        
    }
    
    private void LoadImagesLamps()
    {
        
    }
    
    private void LoadImagesSensors()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}