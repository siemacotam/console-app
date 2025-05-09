namespace HelloWorld.Classes;

using System;
using System.Data.SQLite;
using System.Collections.Generic;

public class Cities
{
    private const string DatabaseFile = "Cities.db";
    private const string ConnectionString = $"Data Source={DatabaseFile};Version=3;";
    private const string TableName = "Cities";
    private const string ColumnName = "Name";

    public Cities()
    {
        CreateDatabaseAndTableIfNotExists();
    }

    private void CreateDatabaseAndTableIfNotExists()
    {
        if (!System.IO.File.Exists(DatabaseFile))
        {
            SQLiteConnection.CreateFile(DatabaseFile);
            using (var dbConnection = new SQLiteConnection(ConnectionString))
            {
                dbConnection.Open();
                string createTableSql = $"CREATE TABLE IF NOT EXISTS {TableName} ({ColumnName} TEXT)";
                using (var command = new SQLiteCommand(createTableSql, dbConnection))
                {
                    command.ExecuteNonQuery();
                }
            }
            Console.WriteLine($"Database '{DatabaseFile}' and table '{TableName}' created.");
        }
    }

    public void AddCity(string cityName)
    {
        using (var dbConnection = new SQLiteConnection(ConnectionString))
        {
            dbConnection.Open();
            string insertSql = $"INSERT INTO {TableName} ({ColumnName}) VALUES (@Name)";
            using (var command = new SQLiteCommand(insertSql, dbConnection))
            {
                command.Parameters.AddWithValue("@Name", cityName);
                command.ExecuteNonQuery();
                Console.WriteLine($"Added city: {cityName}");
            }
        }
    }

    public void RemoveCity(string cityName)
    {
        using (var dbConnection = new SQLiteConnection(ConnectionString))
        {
            dbConnection.Open();
            string deleteSql = $"DELETE FROM {TableName} WHERE {ColumnName} = @Name";
            using (var command = new SQLiteCommand(deleteSql, dbConnection))
            {
                command.Parameters.AddWithValue("@Name", cityName);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine($"Removed city: {cityName}");
                }
                else
                {
                    Console.WriteLine($"City not found: {cityName}");
                }
            }
        }
    }

    public void ListCities()
    {
        List<string> cities = new List<string>();
        using (var dbConnection = new SQLiteConnection(ConnectionString))
        {
            dbConnection.Open();
            string selectSql = $"SELECT {ColumnName} FROM {TableName}";
            using (var command = new SQLiteCommand(selectSql, dbConnection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    cities.Add(reader[ColumnName].ToString());
                }
            }

            if (cities.Count == 0)
            {
                Console.WriteLine("No cities found.");
            }
            else
            {
                Console.WriteLine("List of cities:");
                foreach (string city in cities)
                {
                    Console.WriteLine($"\t{city}");
                }
            }
        }
    }
}


// usage
//
// {
// DatabaseOperations dbOps = new DatabaseOperations();
//
// dbOps.AddCity("London");
// dbOps.AddCity("Paris");
// dbOps.AddCity("Tokyo");
//
// Console.WriteLine("\nList of cities:");
// List<string> cities = dbOps.ListCities();
//     foreach (string city in cities)
// {
//     Console.WriteLine($"- {city}");
// }
//
// dbOps.RemoveCity("Paris");
//
// Console.WriteLine("\nList of cities after removing Paris:");
// cities = dbOps.ListCities();
// foreach (string city in cities)
// {
//     Console.WriteLine($"- {city}");
// }
// }