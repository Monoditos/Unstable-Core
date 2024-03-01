using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Audio", menuName = "Audio", order = 0)]
public class Audio : ScriptableObject
{
    public string audioName;
    public AudioClip clip;
}