using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rock : MonoBehaviour
{

    public float ballSpeed;

    private Rigidbody2D theRB;
    public GameObject rockEffect;

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2((ballSpeed) * transform.localScale.x, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            FindObjectOfType<EnemyFollow>().HurtEnemy();
            FindObjectOfType<EndlessGameManager>().Score();
        }
        if (other.tag == "Player1")
        {
            FindObjectOfType<GameManager>().HurtP1();
        }
        if (other.tag == "Player2")
        {
            FindObjectOfType<GameManager>().HurtP2();
        }
        Instantiate(rockEffect, transform.position, transform.rotation);//Without the transform.position and rotation, the rockEffect game object is spawned in the middle of the play field, position 0,0 rotation 0
        Destroy(gameObject);
    }
    


}
