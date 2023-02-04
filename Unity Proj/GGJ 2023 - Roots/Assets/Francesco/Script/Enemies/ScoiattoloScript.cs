using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoiattoloScript : MonoBehaviour
{
    public GameObject ghianda;
    public Transform origineGhianda;

    public float maxAttesaAttacco = 5f;
    float tempoTrascorsoAttacco;

    private void Update()
    {
        if (tempoTrascorsoAttacco >= maxAttesaAttacco)
        {
            Instantiate(ghianda, origineGhianda.position, Quaternion.identity);
            tempoTrascorsoAttacco = 0;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            tempoTrascorsoAttacco += Time.deltaTime;
            GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.red, tempoTrascorsoAttacco / maxAttesaAttacco);
        }
    }
}
