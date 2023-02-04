using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceveDanno : MonoBehaviour
{
    public bool Colpito = false;
    public string TagDaChiRiceveDanno;
    public int DannoInflitto = 1;
    public bool ilGiocatSalta = true;
    
    
    //In questo caso:
    //"coll" sarebbe chi ha inflitto il danno
    //mentre chi riceve il danno sarebbe il parent a cui sono attaccato
    void OnTriggerEnter2D(Collider2D coll)
   {
        if(coll.gameObject.tag==TagDaChiRiceveDanno)
        {
            GetComponentInParent<Stats>().TogliVita(DannoInflitto);

            //Se mi ha fatto danno il giocatore
            if(coll.gameObject.CompareTag("Player") && ilGiocatSalta)
            {
                Rigidbody2D playerRb = coll.GetComponentInParent<Rigidbody2D>();

                playerRb.velocity = new Vector2(playerRb.velocity.x, 0);
                playerRb.AddForce(Vector2.up * 300f);
            }
        }
   }
}
