using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekcpointObject : MonoBehaviour
{
    [SerializeField] int number;
    [SerializeField] CheckpointSO_Script checkpointScriptableObj;


    private void Update()
    {
        if(checkpointScriptableObj.GetCurrentCheckpointNumber() == number) //Check if the checkpoint number is this
        {
            //SISTEMARE: torna allo stato "attivo"
        }
        else
        {
            //SISTEMARE: torna allo stato "non attivo"
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))  //Check if it's the player
        {
            //
            checkpointScriptableObj.SetCurrentCheckpointNumber(number);
        }
    }
}
