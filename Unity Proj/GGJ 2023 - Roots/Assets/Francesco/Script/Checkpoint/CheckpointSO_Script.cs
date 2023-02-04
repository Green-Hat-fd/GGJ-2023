using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Checkpoint_SO", menuName = "Scriptable Objects/Checkpoint")]
public class CheckpointSO_Script : ScriptableObject
{
    [SerializeField, Min(0)] int currentCheckpoint;
    [SerializeField] Vector2 currentCheckpointPosition;


    //Funzione Get (prende il checkpoint)
    public int GetCurrentCheckpointNumber()
    {
        return currentCheckpoint;
    }

    //Funzione Get (prende la posizione)
    public Vector2 GetCurrentCheckpointPosition()
    {
        return currentCheckpointPosition;
    }

    //Funzione Set (imposta il checkpoint)
    public void SetCurrentCheckpoint(int newCheckpoint, Vector2 newPosition)
    {
        currentCheckpoint = newCheckpoint;
        currentCheckpointPosition = newPosition;
    }
}
