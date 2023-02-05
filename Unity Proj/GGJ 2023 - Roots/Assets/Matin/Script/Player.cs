using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D controller; //Giocatore
    private bool groundedPlayer; //Booleana che determina se il Giocatore sta a contatto con il terreno
    public float playerSpeed;
    public float jumpHeight;
    float moveInput;
    public Transform groundCheck; //Creare collegamento con l'EmptyObject "GroundChecker" dall'inspector di Unity.
    public LayerMask ground; //Selezionare Layer "Ground" assegnato a tutte le piattaforme percorribili.
    public CheckpointSO_Script checkpointSO;
    
    public float tempoAspettareDopoMorte = 2f;
    public float tempoTrascorsoDopoMorte;
    
    public bool isTastoAzionePremuto;
    
    public float invincibilitaSecTot = 10f;
    public float invincibilitaSec;
    public bool sonoInvincibile;

    public AudioSource sfxSalto;
    public AudioSource sfxDanno;
    public AudioSource sfxMorte;

    public Slider sliderVita;



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
        isTastoAzionePremuto = Input.GetKeyDown(KeyCode.E);

        //Quando muore
        if (GetComponent<Stats>().morto)
        {
            //Rende inattivo per poco il giocatore
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

            //TODO: metti il suono della morte del giocatore

            if(tempoTrascorsoDopoMorte >= tempoAspettareDopoMorte)
            {
                //Riprende il gioco dall'ultimo checkpoint
                transform.position = checkpointSO.GetCurrentCheckpointPosition();
                GetComponent<Stats>().RitornoInVita(5);
                GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                
                tempoTrascorsoDopoMorte = 0;
            }
            else
            {
                tempoTrascorsoDopoMorte += Time.deltaTime;
            }
        }
        else  //Resto dei comandi (se non e' morto)
        {
            //Codice che permette il salto, nel caso in cui il giocatore si trovasse in una superfice taggata come "Ground".
            if ((Input.GetKeyDown(KeyCode.W) && groundedPlayer || Input.GetKeyDown(KeyCode.Space)) && groundedPlayer)
            {
                controller.velocity = Vector2.up * jumpHeight;
                //TODO: Aggiungere suono salto
            }

            if (moveInput > 0) //Cambia la direzione dello sprite per il movimento laterale verso destra
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (moveInput < 0) //Cambia la direzione dello sprite per il movimento laterale verso sinistra
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }   
        }

        GetComponent<Stats>().vita = Mathf.Clamp(GetComponent<Stats>().vita, -1, 5);

        if(transform.position.y <= -1000f)
        {
            GetComponent<Stats>().TogliVita(100);
        }

        if (sonoInvincibile)
        {
            if(invincibilitaSec >= invincibilitaSecTot)
            {
                //Quando torna a prendere danno
                invincibilitaSec = 0;
                sonoInvincibile = false;
                GetComponent<SpriteRenderer>().color = Color.white;
            }
            else
            {
                //Quando diventa invincibile
                invincibilitaSec += Time.deltaTime;
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .65f);
            }
        }

        sliderVita.value = GetComponent<Stats>().vita;
    }

    public bool PossoRecuperareVitaDalCespuglio()
    {
        return isTastoAzionePremuto  &&  GetComponent<Stats>().vita < 5;
    }
}
