using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FungoDannoso : MonoBehaviour
{
    public int dannoAlGiocatore = 1;
    public bool siSpegne = true;
    bool spento = false;

    private void Update()
    {
        if (spento)
        {
            /*
             * TODO: Il fungo spento
             */
            GetComponent<SpriteRenderer>().color = Color.grey;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetComponent<Player>().isTastoAzionePremuto)
        {
            collision.GetComponent<Stats>().TogliVita(dannoAlGiocatore);
            spento = siSpegne;
        }
    }
}
