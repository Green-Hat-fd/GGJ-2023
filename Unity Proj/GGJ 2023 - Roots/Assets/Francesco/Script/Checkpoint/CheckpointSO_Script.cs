using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Checkpoint_SO", menuName = "Scriptable Objects/Checkpoint")]
public class CheckpointSO_Script : ScriptableObject
{
    [SerializeField, Min(0)] int currentCheckpoint;


    //Funzione Get (prende il checkpoint)
    public int GetCurrentCheckpointNumber()
    {
        return currentCheckpoint;
    }

    //Funzione Set (imposta il checkpoint)
    public void SetCurrentCheckpointNumber(int newCheckpoint)
    {
        currentCheckpoint = newCheckpoint;
    }
}
