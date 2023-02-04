using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhiandaBehaviour : MonoBehaviour
{
    float tempoTrascorso;
    public float secMaxGhianda = 2f;


    void Update()
    {
        tempoTrascorso += Time.deltaTime;

        if (tempoTrascorso >= secMaxGhianda)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Stats>().TogliVita(1);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
