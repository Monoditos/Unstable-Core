using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
public class LoadToBD : MonoBehaviour
{

    private string bd = "URI=file:./data.db";
    IDbConnection ligacaoBD;

    public void Ligacao()
    {
        ligacaoBD = new SqliteConnection(bd);
        ligacaoBD.Open();
    }

    public void StoreRun()
    {
        Ligacao();
        IDbCommand cmnd = ligacaoBD.CreateCommand();
        cmnd.CommandText = "INSERT INTO Logs (username, time) " +
        "VALUES (@username, @time)";
        //     cmnd.Parameters.Add(new SqliteParameter("@username", SceneManager.GetActiveScene().buildIndex));
        //     cmnd.Parameters.Add(new SqliteParameter("@time", StatsController.GetCoins));
        // }
    }
}