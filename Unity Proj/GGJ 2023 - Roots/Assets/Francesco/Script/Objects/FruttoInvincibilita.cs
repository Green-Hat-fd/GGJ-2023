using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruttoInvincibilita : MonoBehaviour
{
    public GameObject tasto;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetComponent<Player>().isTastoAzionePremuto)
            {
                collision.GetComponent<Player>().sonoInvincibile = true;
                collision.GetComponent<Player>().invincibilitaSec = 0;
                Destroy(gameObject);
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
