using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceveDanno : MonoBehaviour
{
    public bool Colpito = false;
    public string TagDanno;
    public int DannoInflitto = 1;
void OnTriggerStay2D(Collider2D coll)
   {
        if(coll.gameObject.tag==TagDanno)
        {
            Colpito=true;
        }
   }

    void OnTriggerExit2D(Collider2D coll)
   {
        if(coll.gameObject.tag==TagDanno)
        {
            Colpito=false;
        }
   }
}
