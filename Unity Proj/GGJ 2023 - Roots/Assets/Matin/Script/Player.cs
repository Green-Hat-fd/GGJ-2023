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
    public float tempoAspettareDopoMorte = 2f;
    public float tempoTrascorsoDopoMorte;
    public CheckpointSO_Script checkpointSO;

    void Start()
    {
        controller = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(GetComponent<Stats>().morto == false)
        {
            moveInput=Input.GetAxis("Horizontal");
            controller.velocity= new Vector2(playerSpeed*moveInput, controller.velocity.y);
            groundedPlayer=groundCheck.gameObject.GetComponent<Collisione>().IsGrounded;
        }
    }

    void Update()
    {
        //Quando muore
        if(GetComponent<Stats>().morto)
        {
            //Nasconde tutto
            GetComponent<SpriteRenderer>().enabled = false;

            if(tempoTrascorsoDopoMorte >= tempoAspettareDopoMorte)
            {
                //Riprende il gioco dall'ultimo checkpoint
                transform.position = checkpointSO.GetCurrentCheckpointPosition();
                GetComponent<Stats>().RitornoInVita(5);
                GetComponent<SpriteRenderer>().enabled = true;
                
                tempoTrascorsoDopoMorte = 0;
            }
            else
            {
                tempoTrascorsoDopoMorte += Time.deltaTime;
            }
        }
        else  //Resto dei comandi
        {
            //Codice che permette il salto, nel caso in cui il giocatore si trovasse in una superfice taggata come "Ground".
            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && groundedPlayer)
            {
                controller.velocity = Vector2.up * jumpHeight;
            }

            if (moveInput > 0) //Cambia la direzione dello sprite per il movimento laterale verso destra
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (moveInput < 0) //Cambia la direzione dello sprite per il movimento laterale verso sinistra
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }   
        }

        if(transform.position.y <= -100f)
        {
            GetComponent<Stats>().TogliVita(100);
        }
    }
}
