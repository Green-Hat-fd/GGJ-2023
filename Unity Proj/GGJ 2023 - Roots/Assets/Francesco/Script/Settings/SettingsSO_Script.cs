using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Settings_SO", menuName = "Scriptable Objects/Settings")]
public class SettingsSO_Script : ScriptableObject
{
    [SerializeField, Range(0, 1)] float allVolume = 1;


    public float GetVolume()
    {
        return allVolume;
    }

    public void SetVolume(float newVolume)
    {
        allVolume = newVolume;
    }
}
