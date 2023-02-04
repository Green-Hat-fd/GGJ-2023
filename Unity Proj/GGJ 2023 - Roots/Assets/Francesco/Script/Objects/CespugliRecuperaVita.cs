using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CespugliRecuperaVita : MonoBehaviour
{
    public Sprite cespuglioSpento;
    public GameObject tasto;
    public int vitaDaRecuperare = 1;
    bool spento = false;

    private void Update()
    {
        if (spento)
        {
            /*
             * TODO: Il cespuglio che cambia
             */
            GetComponent<SpriteRenderer>().color = Color.grey;
            GetComponent<SpriteRenderer>().sprite = cespuglioSpento;
            tasto.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !spento)
        {
            if (collision.GetComponent<Player>().isTastoAzionePremuto)
            {
                collision.GetComponent<Stats>().AggiungiVita(vitaDaRecuperare);
                spento = true;
            }

            tasto.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && spento == false)
        {
            tasto.SetActive(false);
        }
    }
}
