using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisioneGoomba : MonoBehaviour
{
    public bool AttritoMuro = false;
    public LayerMask ground;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.layer==ground)
        {
            AttritoMuro=true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.layer==ground)
        {
            AttritoMuro=false;
        }
    }
}
