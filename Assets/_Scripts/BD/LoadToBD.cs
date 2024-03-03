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
}
