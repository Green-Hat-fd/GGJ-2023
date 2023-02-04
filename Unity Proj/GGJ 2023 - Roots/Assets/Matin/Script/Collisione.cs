using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisione : MonoBehaviour
{
    public bool IsGrounded;
   void OnTriggerStay2D(Collider2D coll)
   {
        if(coll.gameObject.layer==3)
        {
            IsGrounded=true;
        }
   }

    void OnTriggerExit2D(Collider2D coll)
   {
        if(coll.gameObject.layer==3)
        {
            IsGrounded=false;
        }
   }
}
