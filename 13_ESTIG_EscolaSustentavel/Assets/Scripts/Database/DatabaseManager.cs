using System;

namespace Database
{
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
            OpenConnection();
            CreateTables();
            PopulateDatabase();
            CloseConnection();
        }

        /**
         * Creates tables in database
         */
        private void CreateTables()
        {
            using (DatabaseConnection)
            {
                // Open DB Connection
                OpenConnection();
                // DatabaseConnection.Open();
                DatabaseCommand = DatabaseConnection.CreateCommand();

                // Creates sqlite scrips to create tables
                string lampsTable =
                    "CREATE TABLE IF NOT EXISTS[lamps] (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, name VARCHAR(50) NOT NULL," +
                    " unit_count INTEGER NOT NULL, unit_price REAL NOT NULL, points INTEGER NOT NULL, energy_before INTEGER NOT NULL," +
                    " energy_after INTEGER NOT NULL, power INTEGER NOT NULL, info_text VARCHAR(250) NOT NULL, positive_text VARCHAR(250) NOT NULL, negative_text VARCHAR(250) NOT NULL, image_path VARCHAR(250) NOT NULL, arrangement_image_path VARCHAR(250) NOT NULL);";

                string sensorsTable =
                    "CREATE TABLE IF NOT EXISTS[sensors] (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, name VARCHAR(50) NOT NULL," +
                    " unit_count INTEGER NOT NULL, unit_price REAL NOT NULL, points INTEGER NOT NULL, energy_before INTEGER NOT NULL," +
                    " reach INTEGER NOT NULL, angle INTEGER NOT NULL," +
                    " energy_after INTEGER NOT NULL, info_text VARCHAR(250) NOT NULL, positive_text VARCHAR(250) NOT NULL, negative_text VARCHAR(250) NOT NULL, image_path VARCHAR(250) NOT NULL, arrangement_image_path VARCHAR(250) NOT NULL);";

                string panelsTable =
                    "CREATE TABLE IF NOT EXISTS[panels] (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, name VARCHAR(50) NOT NULL," +
                    " unit_count INTEGER NOT NULL, unit_price REAL NOT NULL, points INTEGER NOT NULL, energy_before INTEGER NOT NULL," +
                    " dimension_w INTEGER NOT NULL, dimension_h INTEGER NOT NULL, power INTEGER NOT NULL," +
                    " energy_after INTEGER NOT NULL, info_text VARCHAR(250) NOT NULL, positive_text VARCHAR(250) NOT NULL, negative_text VARCHAR(250) NOT NULL, image_path VARCHAR(250) NOT NULL, arrangement_image_path VARCHAR(250) NOT NULL);";

                string scoresTable =
                    "CREATE TABLE IF NOT EXISTS[scores] (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, username VARCHAR(50) NOT NULL," +
                    "score INTEGER NOT NULL, timepassed INTEGER NOT NULL, created_at INTEGER NOT NULL, lamp_id INTEGER NOT NULL, " +
                    "panels_id INTEGER NOT NULL, sensors_id INTEGER NOT NULL, " +
                    "FOREIGN KEY(lamp_id) REFERENCES lamps(id), FOREIGN KEY(panels_id) REFERENCES panels(id), FOREIGN KEY(sensors_id) REFERENCES sensors(id)" +
                    ");";

                string generalInfoTable =
                    "CREATE TABLE IF NOT EXISTS[generic_info] (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, info_type VARCHAR(50) NOT NULL, content VARCHAR(250) NOT NULL);";


                // Executes querys
                DatabaseCommand.CommandText = lampsTable;
                DatabaseCommand.ExecuteScalar();
                DatabaseCommand.CommandText = sensorsTable;
                DatabaseCommand.ExecuteScalar();
                DatabaseCommand.CommandText = panelsTable;
                DatabaseCommand.ExecuteScalar();

                DatabaseCommand.CommandText = generalInfoTable;
                DatabaseCommand.ExecuteScalar();

                DatabaseCommand.CommandText = scoresTable;
                DatabaseCommand.ExecuteScalar();

                // Closes DB connection
                CloseConnection();

                print("Done creating db");
            }
        }

        /**
         * Method to populate database
         */
        private void PopulateDatabase()
        {
            using (DatabaseConnection)
            {
                // Open DB Connection
                OpenConnection();
                DatabaseCommand = DatabaseConnection.CreateCommand();

                // Checks if there is any panels rows in DB. If not, populates the lamps table
                if (GetLamps() == null)
                {
                    InsertLampsIntoDB();
                }

                // Checks if there is any panels rows in DB. If not, populates the sensors table
                if (GetSensors() == null)
                {
                    InsertSensorsIntoDB();
                }

                // Checks if there is any panels rows in DB. If not, populates the panels table
                if (GetPanels() == null)
                {
                    InsertPanelsIntoDB();
                }


                // Closes DB connection
                CloseConnection();
            }
        }

        /**
         * A method to insert data into the lamps table
         */
        private void InsertLampsIntoDB()
        {
            using (DatabaseConnection)
            {
                // Open DB Connection
                OpenConnection();
                DatabaseCommand = DatabaseConnection.CreateCommand();

                // Energy before implementation
                int energy_before = 32158;

                // Number of units of each implementation
                int unitLamp1 = 644;
                int unitLamp2 = 448;
                int unitLamp3 = 168;

                // Energy produced by each implementation
                int energySpentLamp1 = (int) (0.1 * 15 * 21);
                int energySpentLamp2 = (int) (0.2 * 15 * 21);
                int energySpentLamp3 = (int) (0.5 * 15 * 21);

                // Paid energy consumed after each implementation
                int energyAfterLamp1 = (int) (energy_before - energySpentLamp1);
                int energyAfterLamp2 = (int) (energy_before - energySpentLamp2);
                int energyAfterLamp3 = (int) (energy_before - energySpentLamp3);

                // Price of each unit of each implementation
                double priceLamp1 = 4.0;
                double priceLamp2 = 11.0;
                double priceLamp3 = 18.0;


                // Values for query
                string lamp1 = "'Lampâdas LED 10W', " + unitLamp1 + ", " + priceLamp1 + ", 100, " + energy_before +
                               ", " + energyAfterLamp1 +
                               ", 10, '', '', '', '', ''";
                string lamp2 = "'Lampâdas LED 20W', " + unitLamp2 + ", " + priceLamp2 +
                               ", 500," + energy_before + ", " + energyAfterLamp2 +
                               ", 20, '', '', '', '', ''";
                string lamp3 = "'Lampâdas LED 50W', " + unitLamp3 +
                               ", " + priceLamp3 + ", 1500, " + energy_before + ", " + energyAfterLamp3 +
                               ", 50, '', '', '','', ''";

                // Query to insert in DB
                string insert =
                    "INSERT INTO lamps(name, unit_count, unit_price, points, energy_before, energy_after, power, info_text, positive_text, negative_text, image_path, arrangement_image_path) VALUES(" +
                    lamp1 + "), (" + lamp2 + "), (" + lamp3 + ");";

                // Executes the insert
                DatabaseCommand.CommandText = insert;
                object ob = DatabaseCommand.ExecuteScalar();

                // Closes DB connection
                CloseConnection();

                // If the object is null, the insert worked. If not, something failed
                if (ob == null)
                {
                    print("Lamps inserted with success!");
                }
                else
                {
                    print("Error while inserting lamps...");
                }
            }
        }

        /**
         * A method to insert data into the Sensors table
         */
        private void InsertSensorsIntoDB()
        {
            using (DatabaseConnection)
            {
                // Open DB Connection
                OpenConnection();
                DatabaseCommand = DatabaseConnection.CreateCommand();

                // Energy before implementation
                int energy_before = 32158;

                // Number of units of each implementation
                int unitSensor1 = 30;
                int unitSensor2 = 15;

                // Energy consumed by each implementation
                int energySpentSensors = (int) (0.26 * 7 * 21);

                // Paid energy consumed after each implementation
                int energyAfterSensors = (int) (energy_before - energySpentSensors);

                // Price of each unit of each implementation
                double priceSensors1 = 8.88;
                double priceSensors2 = 6.91;

                // Reach of each sensor
                int reachSensor = 12;

                // Angle of each sensor
                int angleSensor1 = 180;
                int angleSensor2 = 360;

                // Values for query
                string sensor1 = "'Sensor 180º', " + unitSensor1 + ", " + priceSensors1 + ", " + reachSensor + ", " +
                                 angleSensor1 + ", 500, " + energy_before +
                                 ", " + energyAfterSensors + ",'', '', '', '', ''";
                string sensor2 = "'Sensor 360º', " + unitSensor2 + ", " + priceSensors2 + ", " + reachSensor + ", " +
                                 angleSensor2 + ", 1000," + energy_before + ", " + energyAfterSensors +
                                 ", '', '', '', '', ''";

                // Query to insert in DB
                string insert =
                    "INSERT INTO sensors(name, unit_count, unit_price, reach, angle, points, energy_before, energy_after, info_text, positive_text, negative_text, image_path, arrangement_image_path) VALUES(" +
                    sensor1 + "), (" + sensor2 + ");";

                // Executes the insert
                DatabaseCommand.CommandText = insert;
                object ob = DatabaseCommand.ExecuteScalar();

                // Closes DB connection
                CloseConnection();

                // If the object is null, the insert worked. If not, something failed
                if (ob == null)
                {
                    print("Sensors inserted with success!");
                }
                else
                {
                    print("Error while inserting Sensors...");
                }
            }
        }

        /**
         * A method to insert data into the panels table
         */
        private void InsertPanelsIntoDB()
        {
            using (DatabaseConnection)
            {
                // Open DB Connection
                OpenConnection();
                DatabaseCommand = DatabaseConnection.CreateCommand();

                // Energy before implementation
                int energy_before = 17781;

                // Number of units of each implementation
                int unitPanel1 = 780;
                int unitPanel2 = 161;
                int unitPanel3 = 941;

                // Energy produced by each implementation
                int energyProducedPanel1 = (int) Math.Floor(((2.4 * unitPanel1) + (4 * unitPanel1)) / 2);
                int energyProducedPanel2 = (int) Math.Floor(((39.6 * unitPanel2) + (66 * unitPanel2)) / 2);
                int energyProducedPanel3 = (int) (energyProducedPanel1 + energyProducedPanel2);

                // Paid energy consumed after each implementation
                int energyAfterPanel1 = (int) (energy_before - energyProducedPanel1);
                int energyAfterPanel2 = (int) (energy_before - energyProducedPanel2);
                int energyAfterPanel3 = (int) (energy_before - energyProducedPanel3);

                // Price of each unit of each implementation
                double pricePanel1 = 48.51;
                double pricePanel2 = 122.0;
                double pricePanel3 = pricePanel1 + pricePanel2;

                // Units sizes
                int panelw1 = 365;
                int panelh1 = 450;

                int panelw2 = 1956;
                int panelh2 = 992;

                int panelw3 = panelw1 + panelw2;
                int panelh3 = panelh1 + panelh2;

                // Values for query
                string panel1 = "'Painéis Solares no Estacionamento', " + unitPanel1 + ", " + pricePanel1 + ", 2000," +
                                panelw1 + "," + panelh1 + ", " + energy_before + ", " + energyAfterPanel1 +
                                ", 20, '', '', '', '', ''";
                string panel2 = "'Painéis Solares no Telhado do Edifício Escolar', " + unitPanel2 + ", " + pricePanel2 +
                                ", 3000," +
                                panelw2 + "," + panelh2 + ", " + energy_before + ", " + energyAfterPanel2 +
                                ", 330, '', '', '', '', ''";
                string panel3 = "'Painéis Solares no Estacionamento e no Telhado do Edifício Escolar', " + unitPanel3 +
                                ", " + pricePanel3 + ", 1000," +
                                panelw3 + "," + panelh3 + ", " + energy_before + ", " + energyAfterPanel3 +
                                ", 350, '', '', '', '', ''";

                // Query to insert in DB
                string insert =
                    "INSERT INTO panels(name, unit_count, unit_price, points, dimension_w, dimension_h, energy_before, energy_after, power, info_text, positive_text, negative_text, image_path, arrangement_image_path) VALUES(" +
                    panel1 + "), (" + panel2 + "), (" + panel3 + ");";

                // Executes the insert
                DatabaseCommand.CommandText = insert;
                object ob = DatabaseCommand.ExecuteScalar();

                // Closes DB connection
                CloseConnection();

                // If the object is null, the insert worked. If not, something failed
                if (ob == null)
                {
                    print("Panels inserted with success!");
                }
                else
                {
                    print("Error while inserting panels...");
                }
            }
        }


        /**
         * Gets rows from Lamps table
         */
        public object GetLamps()
        {
            using (DatabaseConnection)
            {
                // Open DB Connection
                OpenConnection();
                DatabaseCommand = DatabaseConnection.CreateCommand();

                string queryCheckIfExistsLamps = "SELECT * FROM lamps";
                DatabaseCommand.CommandText = queryCheckIfExistsLamps;
                object ob = DatabaseCommand.ExecuteScalar();

                // Closes DB connection
                CloseConnection();

                return ob;
            }
        }

        /**
         * Gets rows from Sensors table
         */
        public object GetSensors()
        {
            using (DatabaseConnection)
            {
                // Open DB Connection
                OpenConnection();
                DatabaseCommand = DatabaseConnection.CreateCommand();

                string queryCheckIfExistsSensors = "SELECT * FROM sensors";
                DatabaseCommand.CommandText = queryCheckIfExistsSensors;
                object ob = DatabaseCommand.ExecuteScalar();

                // Closes DB connection
                CloseConnection();

                return ob;
            }
        }


        /**
         * Gets rows from Panels table
         */
        public object GetPanels()
        {
            using (DatabaseConnection)
            {
                // Open DB Connection
                OpenConnection();
                DatabaseCommand = DatabaseConnection.CreateCommand();

                string queryCheckIfExistsPanels = "SELECT * FROM panels";
                DatabaseCommand.CommandText = queryCheckIfExistsPanels;
                object ob = DatabaseCommand.ExecuteScalar();

                // Closes DB connection
                CloseConnection();

                return ob;
            }
        }


        /**
         * Opens DB Connection
         */
        private void OpenConnection()
        {
            if (DatabaseConnection.State == ConnectionState.Closed)
            {
                DatabaseConnection.Open();
            }
        }

        /**
         * Closes DB Connection
         */
        private void CloseConnection()
        {
            if (DatabaseConnection.State == ConnectionState.Open)
            {
                DatabaseConnection.Close();
            }
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}