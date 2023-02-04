using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaBehaviour : MonoBehaviour
{
    private Rigidbody2D goomba;
    private bool grounded;
    public float GoombaSpeed;
    public Transform groundCheck;
    public Transform muroCheck;
    public Transform vuotoCheck;
    public Transform Danneggiato;
    public LayerMask ground;
    public int VitaGoomba = 1;
    public bool Morto = false;
    public bool vadoADestra = true;

    // Start is called before the first frame update
    void Start()
    {
        goomba=GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        grounded=groundCheck.gameObject.GetComponent<Collisione>().IsGrounded;
        
        if(muroCheck.gameObject.GetComponent<CollisioneGoomba>().checkMuro || vuotoCheck.gameObject.GetComponent<VuotoGoomba>().checkVuotoSotto)
        {
            vadoADestra = !vadoADestra;
            muroCheck.gameObject.GetComponent<CollisioneGoomba>().checkMuro = false;
            vuotoCheck.gameObject.GetComponent<VuotoGoomba>().checkVuotoSotto = false;
        }
        
        if(vadoADestra && grounded)
        {
            goomba.velocity = new Vector2(GoombaSpeed, goomba.velocity.y);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            goomba.velocity = new Vector2(-GoombaSpeed, goomba.velocity.y);
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if(Danneggiato.gameObject.GetComponent<RiceveDanno>().Colpito==true)
        {
            VitaGoomba = VitaGoomba - 1;
        }

        if(VitaGoomba<=0)
        {
            Morto= true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
                if(Morto==true)
        {
            Destroy(gameObject);
        }
    }
}
