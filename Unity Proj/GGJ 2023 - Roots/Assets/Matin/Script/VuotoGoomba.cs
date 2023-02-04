using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VuotoGoomba : MonoBehaviour
{
    public bool checkVuotoSotto = false;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 3) //Se il layer è il Ground
        {
            checkVuotoSotto = true;
        }
    }
}
