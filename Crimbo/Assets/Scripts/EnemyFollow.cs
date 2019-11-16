using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform target;
    private float speed;
    public GameObject deathEffect;
    public int enemyLife;

   
    // Start is called before the first frame update
    void Start()
    {
        enemyLife = Random.Range(1, 10);
        speed = Random.Range(1f, 10f);
        target = GameObject.FindGameObjectWithTag("SinglePlayer").GetComponent<Transform>();
    }


    // Update is called once per frame
    void Update()
    {
        /*if (theRB.velocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (theRB.velocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }*/
        if (enemyLife <= 0)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            FindObjectOfType<scoring>().ScoreUp();
        }
        /*transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);*/
    }
    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "SinglePlayer")
        {
            FindObjectOfType<EndlessGameManager>().HealthbarDown();
            Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    public void HurtEnemy()
    {
        enemyLife -= Random.Range(4, 10);
        FindObjectOfType<EndlessGameManager>().hurtSound.Play();
    }
   
}
