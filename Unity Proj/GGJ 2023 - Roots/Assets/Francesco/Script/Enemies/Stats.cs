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
        vita -= daTogliere;
    }

    public void AggiungiVita(int daAggiungere)
    {
        vita += daAggiungere;
    }

    public void RitornoInVita(int newVita)
    {
        vita = newVita;
        morto = false;
    }
}
