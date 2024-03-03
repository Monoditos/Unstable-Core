using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class CreateDB : MonoBehaviour
{
    private string bd = "URI=file:./data.db";
    IDbConnection ligacaoBD;
    private void Awake()
    {
        CriarBD();
    }
    public void Ligacao()
    {
        ligacaoBD = new SqliteConnection(bd);
        ligacaoBD.Open();
    }
    public void CriarBD()
    {
        Ligacao();
        IDbCommand cmnd = ligacaoBD.CreateCommand();
        string q_criarTabelas = "CREATE TABLE IF NOT EXISTS Logs " +
                                      "(logsID INTEGER PRIMARY KEY AUTOINCREMENT, username VARCHAR(50), " +
                                      "time REAL);";
        cmnd.CommandText = q_criarTabelas;
        cmnd.ExecuteReader();
        ligacaoBD.Close();
    }
}
