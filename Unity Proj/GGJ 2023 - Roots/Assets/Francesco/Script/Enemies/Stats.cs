using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int vita;
    public bool morto;


    private void Update()
    {
        morto = vita<=0 ? true : false;
    }

    public void TogliVita(int daTogliere)
    {
        switch(gameObject.tag)
        {
            case "Player":
                if(!GetComponent<Player>().sonoInvincibile)
                    vita -= daTogliere;
                
                //TODO: metti il suono del danno del giocatore
                break;

            default:
                vita -= daTogliere;
                
                if(vita <= 0)
                {
                    //TODO: metti il suono della morte del nemico
                }
                else
                {
                    //TODO: metti il suono del danno del nemico
                }
                break;
        }
    }

    public void AggiungiVita(int daAggiungere)
    {
        vita += daAggiungere;

        if (gameObject.CompareTag("Player"))
        {
            //TODO: metti il suono di aggiungere la vita
        }
    }

    public void RitornoInVita(int newVita)
    {
        vita = newVita;
        morto = false;

        if (gameObject.CompareTag("Player"))
        {
            //TODO: metti il suono del restart dal checkpoint
        }
    }
}
