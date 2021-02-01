namespace Database
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Mono.Data.Sqlite;
    using System.Data;
    public class DatabaseManager : MonoBehaviour
    {
        private string DatabaseName = "/Database/13_estig_escola_sustentavel.db";
        SqliteConnection DatabaseConnection;
        SqliteCommand DatabaseCommand;
        // Start is called before the first frame update
        void Start()
        {
            string filepath = "URI=file:" + Application.dataPath + DatabaseName;
            Debug.Log("dataPath : " + Application.dataPath);
            //string conn = "URI=file:" + filepath;
            //var dbconn = new SqliteConnection(conn);
            DatabaseConnection = new SqliteConnection(filepath);
            CreateTable();
            PopulateDatabase();
        }
        
        private void CreateTable()
        {
            using (DatabaseConnection)
            {
                DatabaseConnection.Open();
                DatabaseCommand = DatabaseConnection.CreateCommand();
                
                string lampsTable = "CREATE TABLE IF NOT EXISTS[lamps] (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, name VARCHAR(50) NOT NULL," + 
                                    " unit_count INTEGER NOT NULL, unit_price REAL NOT NULL, points INTEGER NOT NULL, energy_before INTEGER NOT NULL," + 
                                    " energy_after INTEGER NOT NULL, power INTEGER NOT NULL, info_text VARCHAR(250) NOT NULL, positive_text VARCHAR(250) NOT NULL, negative_text VARCHAR(250) NOT NULL);";
                
                string senorsTable = "CREATE TABLE IF NOT EXISTS[sensors] (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, name VARCHAR(50) NOT NULL," + 
                                     " unit_count INTEGER NOT NULL, unit_price REAL NOT NULL, points INTEGER NOT NULL, energy_before INTEGER NOT NULL," +
                                     " reach INTEGER NOT NULL, angle INTEGER NOT NULL," +
                                     " energy_after INTEGER NOT NULL, info_text VARCHAR(250) NOT NULL, positive_text VARCHAR(250) NOT NULL, negative_text VARCHAR(250) NOT NULL);";
                
                string panelsTable = "CREATE TABLE IF NOT EXISTS[panels] (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, name VARCHAR(50) NOT NULL," + 
                                     " unit_count INTEGER NOT NULL, unit_price REAL NOT NULL, points INTEGER NOT NULL, energy_before INTEGER NOT NULL," + 
                                     " dimension_w INTEGER NOT NULL, dimension_h INTEGER NOT NULL, power INTEGER NOT NULL," +
                                     " energy_after INTEGER NOT NULL, info_text VARCHAR(250) NOT NULL, positive_text VARCHAR(250) NOT NULL, negative_text VARCHAR(250) NOT NULL);";
                
                string scoresTable = "CREATE TABLE IF NOT EXISTS[scores] (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, username VARCHAR(50) NOT NULL," + 
                                     "score INTEGER NOT NULL, timepassed INTEGER NOT NULL, created_at INTEGER NOT NULL, lamp_id INTEGER NOT NULL, " + 
                                     "panels_id INTEGER NOT NULL, sensors_id INTEGER NOT NULL, " + 
                                     "FOREIGN KEY(lamp_id) REFERENCES lamps(id), FOREIGN KEY(panels_id) REFERENCES panels(id), FOREIGN KEY(sensors_id) REFERENCES sensors(id)" + 
                                     ");";
    
                string generalInfoTable = "CREATE TABLE IF NOT EXISTS[generic_info] (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, info_type VARCHAR(50) NOT NULL, content VARCHAR(250) NOT NULL);";
                
                DatabaseCommand.CommandText = lampsTable;
                DatabaseCommand.ExecuteScalar();
                DatabaseCommand.CommandText = senorsTable;
                DatabaseCommand.ExecuteScalar();
                DatabaseCommand.CommandText = panelsTable;
                DatabaseCommand.ExecuteScalar();
                
                DatabaseCommand.CommandText = generalInfoTable;
                DatabaseCommand.ExecuteScalar();
                
                DatabaseCommand.CommandText = scoresTable;
                DatabaseCommand.ExecuteScalar();
    
                DatabaseConnection.Close();
                
                print("done creating db");
            }
        }
        
        private void PopulateDatabase()
        {
            using (DatabaseConnection)
            {
                DatabaseConnection.Open();
                DatabaseCommand = DatabaseConnection.CreateCommand();
                
                
                
            }
        }
        
        
        // Update is called once per frame
        void Update()
        {
            
        }
    
    }
}


