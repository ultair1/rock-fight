using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollieController : MonoBehaviour
{
    private Transform target;
    private float speed;
    public GameObject deathEffect;
    public int enemyLife;
    private Rigidbody2D theRB;
    public Animator anim;

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(4f);
    }
    // Start is called before the first frame update
    void Start()
    {
        enemyLife = Random.Range(10, 30);
        speed = Random.Range(1f, 10f);
        target = GameObject.FindGameObjectWithTag("SinglePlayer").GetComponent<Transform>();
        theRB = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (theRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (theRB.velocity.y < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (theRB.velocity.y > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (enemyLife <= 0)
        {
            anim.SetTrigger("Death");
            StartCoroutine(Pause());
            Destroy(gameObject);
        }
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, target.position) <= 0)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            FindObjectOfType<EndlessGameManager>().HealthbarDown();
        }
    }
    public void HurtEnemy()
    {
        enemyLife -= Random.Range(10, 20);
        FindObjectOfType<EndlessGameManager>().hurtSound.Play();
    }

}
