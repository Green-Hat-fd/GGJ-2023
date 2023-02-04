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
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            goomba.velocity = new Vector2(-GoombaSpeed, goomba.velocity.y);
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        vadoADestra = !vadoADestra;
        muroCheck.gameObject.GetComponent<CollisioneGoomba>().checkMuro = false;
        vuotoCheck.gameObject.GetComponent<VuotoGoomba>().checkVuotoSotto = false;

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Stats>().TogliVita(1);
        }
    }

    private void LateUpdate()
    {
        if(GetComponent<Stats>().morto==true)
        {
            Destroy(gameObject);
        }
    }
}
