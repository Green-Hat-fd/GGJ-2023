using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisione : MonoBehaviour
{
    public bool IsGrounded;
   void OnTriggerStay2D(Collider2D coll)
   {
        if(coll.gameObject.tag=="Ground")
        {
            IsGrounded=true;
        }
   }

    void OnTriggerExit2D(Collider2D coll)
   {
        if(coll.gameObject.tag=="Ground")
        {
            IsGrounded=false;
        }
   }
}
