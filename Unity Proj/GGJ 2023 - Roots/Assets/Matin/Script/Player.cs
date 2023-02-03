using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D controller; //Giocatore
    private bool groundedPlayer; //Booleana che determina se il Giocatore sta a contatto con il terreno
    public float playerSpeed;
    public float jumpHeight;
    float moveInput;
    public Transform groundCheck; //Creare collegamento con l'EmptyObject "GroundChecker" dall'inspector di Unity.
    public LayerMask ground; //Selezionare Layer "Ground" assegnato a tutte le piattaforme percorribili.

    void Start()
    {
        controller = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    { 
        moveInput=Input.GetAxis("Horizontal");
        controller.velocity= new Vector2(playerSpeed*moveInput, controller.velocity.y);
        groundedPlayer=groundCheck.gameObject.GetComponent<Collisione>().IsGrounded;

    }

    void Update()
    {
        //Codice che permette il salto, nel caso in cui il giocatore si trovasse in una superfice taggata come "Ground".
         if(Input.GetKeyDown(KeyCode.W) && groundedPlayer)
        {
            controller.velocity= Vector2.up*jumpHeight;
        }
            if(moveInput>0) //Cambia la direzione dello sprite per il movimento laterale verso destra
            {
                controller.transform.localScale= new Vector3(1,1,1);
            }
              else if(moveInput<0) //Cambia la direzione dello sprite per il movimento laterale verso sinistra
            {
                controller.transform.localScale= new Vector3(-1,1,1);
            }
    }
}
