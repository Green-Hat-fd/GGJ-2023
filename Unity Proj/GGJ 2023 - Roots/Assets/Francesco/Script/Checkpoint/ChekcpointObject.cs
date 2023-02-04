using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekcpointObject : MonoBehaviour
{
    [SerializeField] int number;
    [SerializeField] CheckpointSO_Script checkpointScrObj;


    private void Update()
    {
        //Controlla se il checkpoint attivo è questo
        if(checkpointScrObj.GetCurrentCheckpointNumber() == number)
        {
            /*
             * SISTEMARE: torna allo stato "attivo"/luminoso
             */
        }
        else
        {
            /*
             * SISTEMARE: torna allo stato "non attivo"/spento
             */
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Controlla che sia il giocatore a collidere & che non l'ha già preso
        if (other.gameObject.CompareTag("Player")
             &&
            checkpointScrObj.GetCurrentCheckpointNumber() == number)
        {
            //Imposta il checkpoint con questo
            checkpointScrObj.SetCurrentCheckpointNumber(number);
        }
    }
}
