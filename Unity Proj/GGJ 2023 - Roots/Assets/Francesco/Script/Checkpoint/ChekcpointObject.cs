using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekcpointObject : MonoBehaviour
{
    [SerializeField] int number;
    [SerializeField] CheckpointSO_Script checkpointScrObj;
    [SerializeField] GameObject lucette;


    private void Awake()
    {
        //Imposta il primo checkpoint il n. 0
        if(number == 0)
            checkpointScrObj.SetCurrentCheckpoint(number, transform.position);
    }

    private void Update()
    {
        //Controlla se il checkpoint attivo è questo
        if(checkpointScrObj.GetCurrentCheckpointNumber() == number)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            lucette.SetActive(true);

            //TODO: metti il suono del checkpoint che si attiva
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.gray;
            lucette.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Controlla che sia il giocatore a collidere & che non l'ha già preso
        if (collision.gameObject.CompareTag("Player")
             &&
            checkpointScrObj.GetCurrentCheckpointNumber() != number)
        {
            //Imposta il checkpoint con questo
            checkpointScrObj.SetCurrentCheckpoint(number, transform.position);
        }
    }
}
