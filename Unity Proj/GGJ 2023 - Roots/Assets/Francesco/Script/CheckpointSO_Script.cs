using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Checkpoint_SO", menuName = "Scriptable Objects/")]
public class CheckpointSO_Script : MonoBehaviour
{
    int currentCheckpoint;


    public int GetCurrentCheckpointNumber()
    {
        return currentCheckpoint;
    }

    public void SetCurrentCheckpointNumber(int newCheckpoint)
    {
        currentCheckpoint = newCheckpoint;
    }
}
