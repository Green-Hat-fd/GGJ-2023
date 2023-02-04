using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisioneGoomba : MonoBehaviour
{
    public bool checkMuro = false;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.layer == 3) //Se il layer è il Ground
        {
            checkMuro=true;
        }
    }
}
