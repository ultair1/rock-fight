using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public Transform throwPoint;
    public Transform throwPointS;
    public GameObject rockBall;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode throwRock;
    public KeyCode melee;
    public Transform groundCheckPoint;
    public bool isGrounded;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public AudioSource throwSound;
    public GameObject speedEffect;
    public GameObject strengthEffect;
    public GameObject strengthBall;
    public GameObject ShieldEffect;
    public GameObject meleeHitbox;
/*    public Transform meleePoint0;
    public Transform meleePoint1;
    public Transform meleePoint2;*/
    public bool strength;

    private Rigidbody2D theRB;
    private Animator anim;


    IEnumerator Speed(GameObject powerup) //(GameObject powerup allows for the powerup to be deleted without deleting the player
    {
        moveSpeed = moveSpeed+5;
        jumpForce = jumpForce + 5;
        Instantiate(speedEffect, theRB.position, transform.rotation);
        Destroy(powerup); // destroys the powerup so that the player can't activate it more than once
        yield return new WaitForSeconds(5f);
        Instantiate(speedEffect, theRB.position, transform.rotation);
        moveSpeed = moveSpeed-5;
        jumpForce = jumpForce - 5;
     }
    IEnumerator Shield(GameObject powerup)
    {
        if (tag == "Player1")
        {
            FindObjectOfType<GameManager>().Shield();//This called the shield function from the game manager, causing the life of the character that picks it up to increase by 5
            Instantiate(ShieldEffect, theRB.position, transform.rotation);
            Destroy(powerup);
        } else if (tag == "Player2")
        {
            FindObjectOfType<GameManager>().Shield();//This called the shield function from the game manager, causing the life of the character that picks it up to increase by 5
            Instantiate(ShieldEffect, theRB.position, transform.rotation);
            Destroy(powerup);
        }
        if (tag == "SinglePlayer")
        {
            FindObjectOfType<EndlessGameManager>().HealthbarUp();//Since the health works differently in the endless mode, this is neccessary
            Instantiate(ShieldEffect, theRB.position, transform.rotation);
            Destroy(powerup);
        }
        yield return new WaitForSeconds(0f);
    }
    IEnumerator Strength(GameObject powerup) //(GameObject powerup allows for the powerup to be deleted without deleting the player
    {
        Strength();
        Instantiate(strengthEffect, theRB.position, transform.rotation);
        Destroy(powerup); // destroys the powerup so that the player can't activate it more than once
        yield return new WaitForSeconds(5f);
        Instantiate(strengthEffect, theRB.position, transform.rotation);
        Strengths();
    }

 /*   IEnumerator Punch() 
    {
        Instantiate(meleeHitbox, meleePoint0.position, meleePoint0.rotation);
        yield return new WaitForSeconds(0.2f);
        Instantiate(meleeHitbox, meleePoint1.position, meleePoint1.rotation);
        yield return new WaitForSeconds(0.2f);
        Instantiate(meleeHitbox, meleePoint2.position, meleePoint2.rotation);
    }*/
    //Use this for initialisation 
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        strength = false;
    }
    public void Strength()
    {
        strength = true;
    }
    public void Strengths()
    {
        strength = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Speed"))
        {
            StartCoroutine(Speed(collision.gameObject));
        }
        if (collision.gameObject.CompareTag("Strength"))
        {
            StartCoroutine(Strength(collision.gameObject));
        }
        if (collision.gameObject.CompareTag("Shield"))
        {
            StartCoroutine(Shield(collision.gameObject));
        }
    }

    //Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
        if (Input.GetKey(left))
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
        } else if (Input.GetKey(right))
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
        } else
        {
            theRB.velocity = new Vector2(0, theRB.velocity.y);
        }
        if (Input.GetKeyDown(jump) && isGrounded)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }

        if (theRB.velocity.x <0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        } else if (theRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }   
        if (Input.GetKeyDown(throwRock))
        {
           GameObject rockClone =  (GameObject)Instantiate(rockBall, throwPoint.position, throwPoint.rotation);
            rockClone.transform.localScale = transform.localScale;
            anim.SetTrigger("Throw");
            throwSound.Play();
        }
        if (Input.GetKeyDown(throwRock) && strength)
        {
            GameObject rockCloneS = (GameObject)Instantiate(strengthBall, throwPointS.position, throwPointS.rotation);
             rockCloneS.transform.localScale = transform.localScale;
             anim.SetTrigger("Throw");
             throwSound.Play();
        }
/*        if (Input.GetKeyDown(melee))
        {
            StartCoroutine(Punch());
            anim.SetTrigger("Melee");
        }*/
        anim.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("Grounded", isGrounded);

    }


}