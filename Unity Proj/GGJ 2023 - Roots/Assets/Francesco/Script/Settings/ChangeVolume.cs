using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVolume : MonoBehaviour
{
    [SerializeField] SettingsSO_Script settings_ScrObj;
     

    void Update()
    {
        GetComponent<AudioSource>().volume *= settings_ScrObj.GetVolume();
    }
}
