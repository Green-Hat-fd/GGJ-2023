using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApeScript : MonoBehaviour
{
    Vector3 posizIniziale;
    public float sinMin = -2.5f,
                 sinMax = 2.5f;
    public float velocity = 1;
    public float minTempoAttacco,
                 maxTempoAttacco;
    float tempoPassato;

    public GameObject proiettile;
    public Transform origineProiett;


    private void Start()
    {
        posizIniziale = transform.position;
    }

    private void Update()
    {
        transform.localPosition = posizIniziale + Vector3.up * CustomFunctions.NuovaOndaSenoMinMax(sinMin, sinMax, Time.time * velocity);

        if (tempoPassato >= Random.Range(minTempoAttacco, maxTempoAttacco))
        {
            /*
             * ATTACCO
             */
            Instantiate(proiettile, origineProiett.position, transform.rotation);
            tempoPassato = 0;
        }
        else
        {
            tempoPassato += Time.deltaTime;
        }
    }
}
