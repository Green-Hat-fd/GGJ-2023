using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruttoInvincibilita : MonoBehaviour
{
    public Sprite cespuglioSpento;
    public GameObject tasto;
    bool spento = false;


    private void Update()
    {
        if (spento)
        {
            GetComponent<SpriteRenderer>().sprite = cespuglioSpento;
            tasto.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetComponent<Player>().isTastoAzionePremuto)
            {
                collision.GetComponent<Player>().sonoInvincibile = true;
                collision.GetComponent<Player>().invincibilitaSec = 0;
                spento = true;
            }

            tasto.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tasto.SetActive(false);
        }
    }
}
