using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit2D(Collider2D other)
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
    }
}
