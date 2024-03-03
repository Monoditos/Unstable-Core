using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class Leaderbord : MonoBehaviour
{
    [SerializeField] private TMP_Text usernames, times;
    private string bd = "URI=file:./data.db";
    IDbConnection ligacaoBD;

    public void Ligacao()
    {
        ligacaoBD = new SqliteConnection(bd);
        ligacaoBD.Open();
    }

    private void OnEnable()
    {
        Ligacao();
        IDbCommand comandoBD = ligacaoBD.CreateCommand();
        string sqlQuery = "SELECT username, time FROM Logs ORDER BY time DESC LIMIT 10;";
        comandoBD.CommandText = sqlQuery;
        IDataReader reader = comandoBD.ExecuteReader();

        int i = 0;
        while (reader.Read() && i < 10)
        {
            string username = reader[0].ToString();
            string time = reader[1].ToString();

            usernames.text += username + "\n"; ;
            times.text += time + "\n";

            i++;
        }

        for (; i < 10; i++)
        {
            usernames.text += "---\n";
            times.text += "---\n";
        }

        reader.Close();
        reader = null;
        comandoBD.Dispose();
        comandoBD = null;
        ligacaoBD.Close();
        ligacaoBD = null;

    }
}