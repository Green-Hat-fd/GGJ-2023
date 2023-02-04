using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompDamage : MonoBehaviour
{
    public int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            damage = 1;
        }
    }
}