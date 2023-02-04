using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaBehaviour : MonoBehaviour
{
    private Rigidbody2D goomba;
    private bool grounded;
    public float GoombaSpeed;
    public Transform groundCheck;
    public LayerMask ground;
    public int VitaGoomba = 1;
    public bool Morto = false;
    public bool Destra = true;
    public Transform muroCheck;

    // Start is called before the first frame update
    void Start()
    {
        goomba=GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        grounded=groundCheck.gameObject.GetComponent<Collisione>().IsGrounded;
        if(muroCheck.gameObject.GetComponent<CollisioneGoomba>().AttritoMuro)
        {
            Destra = !Destra;
            muroCheck.gameObject.GetComponent<CollisioneGoomba>().AttritoMuro = false;
        }
        if(Destra && grounded)
        {
            goomba.velocity=new Vector2(GoombaSpeed, goomba.velocity.y);
        }
        else
        {
            goomba.velocity=new Vector2(-GoombaSpeed, goomba.velocity.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
