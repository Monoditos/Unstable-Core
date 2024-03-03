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
    public Timer timer;
    public TMP_InputField username;
    private string bd = "URI=file:./data.db";
    IDbConnection ligacaoBD;

    public void Ligacao()
    {
        ligacaoBD = new SqliteConnection(bd);
        ligacaoBD.Open();
    }

    public void StoreRun()
    {
        float tempo = Mathf.Round(timer.elapsedTime * 100.0f) / 100.0f;
        Ligacao();
        IDbCommand cmnd = ligacaoBD.CreateCommand();
        cmnd.CommandText = "INSERT INTO Logs (username, time) " +
            "VALUES (@username, @time)";
        cmnd.Parameters.Add(new SqliteParameter("@username", username.text));
        cmnd.Parameters.Add(new SqliteParameter("@time", tempo));
        cmnd.ExecuteNonQuery();
        ligacaoBD.Close();
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}