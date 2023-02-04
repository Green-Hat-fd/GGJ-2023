using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimProiettile : MonoBehaviour
{
    public float velocity = 7.5f;
    float tempoTrascorso;
    public float secMaxProiett = 10f;

    void Update()
    {
        transform.position += transform.right * velocity * Time.deltaTime;

        tempoTrascorso += Time.deltaTime;
        if (tempoTrascorso >= secMaxProiett)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
