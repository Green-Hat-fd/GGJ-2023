using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int vita;
    public bool morto;
    public AudioSource sfxNemicoDanno;
    public AudioSource sfxNemicoMorto;


    private void Update()
    {
        morto = vita<=0 ? true : false;
    }

    public void TogliVita(int daTogliere)
    {
        switch(gameObject.tag)
        {
            case "Player":
                if (!GetComponent<Player>().sonoInvincibile)
                {
                    vita -= daTogliere;
                    GetComponent<Player>().sonoInvincibile = true;
                    GetComponent<Player>().invincibilitaSec = 0;
                    GetComponent<Player>().invincibilitaSecTot = 2;
                    //GetComponent<Player>().sfxDanno.Play();
                }
                break;

            default:
                vita -= daTogliere;
                
                /*if(vita <= 0)
                {
                    sfxNemicoMorto.Play();
                }
                else
                {
                    sfxNemicoDanno.Play();
                }*/
                break;
        }
    }

    public void AggiungiVita(int daAggiungere)
    {
        vita += daAggiungere;

        if (gameObject.CompareTag("Player"))
        {
            //GetComponent<Player>().sfxRecuperaVita.Play();
        }
    }

    public void RitornoInVita(int newVita)
    {
        vita = newVita;
        morto = false;

        if (gameObject.CompareTag("Player"))
        {
            GetComponent<Player>().sfxTornoAlCheckpoint.Play();
        }
    }
}
