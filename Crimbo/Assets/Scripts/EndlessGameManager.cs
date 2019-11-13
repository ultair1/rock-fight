using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CodeMonkey.Utils;
using UnityEngine.UI;

public class EndlessGameManager : MonoBehaviour
{
    [SerializeField]
    private HealthBar healthBar;
    public GameObject player1;
    public GameObject kamikazeBird;
    public GameObject gameOver;
    public GameObject[] p1Hearts;
    public float score;
    public AudioSource hurtSound;
    public float health;
    public Transform movement;



    public string mainMenu;

    public int p1Life;
    public GameObject three;
    public AudioSource tres;
    public GameObject two;
    public AudioSource dos;
    public GameObject one;
    public AudioSource uno;
    public GameObject survive;
    public AudioSource surviving;
    public AudioSource backgroundMusic;


    IEnumerator going() //(GameObject powerup allows for the powerup to be deleted without deleting the player
    {
        three.SetActive(true);
        tres.Play();
        yield return new WaitForSeconds(1f);
        three.SetActive(false);
        two.SetActive(true);
        dos.Play();
        yield return new WaitForSeconds(1f);
        two.SetActive(false);
        one.SetActive(true);
        uno.Play();
        yield return new WaitForSeconds(1f);
        one.SetActive(false);
        survive.SetActive(true);
        surviving.Play();
        yield return new WaitForSeconds(1f);
        survive.SetActive(false);
        backgroundMusic.Play();
    }
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(going());
        score = 0;
        gameOver.SetActive(false);
        player1.SetActive(true);
        movement = player1.transform;
        health = 1f;
        FunctionPeriodic.Create(() =>
        {
            if (health > 0)
            {
                healthBar.SetSize(health);

                if (health < .3f)//under 30% health
                {
                    if ((health * 100f) % 3 == 0)
                    {
                        healthBar.SetColor(Color.white);
                    }
                    else
                    {
                        healthBar.SetColor(Color.red);
                    }
                }
            }
        }, .3f);
        
    }
    public void HealthbarDown()
    {
        if (health > 0)
        {
            health -= Random.Range(.01f, .03f);
        }
        if (health < 0)
        {
            healthBar.SetSize(0f);
        }
    }
    public void HealthbarUp()
    {
        if (health > 0)
        {
            health += Random.Range(.01f, .05f);
        }
        if (health < 0)
        {
            healthBar.SetSize(0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) if (Input.GetKeyDown(KeyCode.LeftControl))
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
        SceneManager.LoadScene(mainMenu);
        }
        if (p1Life <= 0)
        {
        player1.SetActive(false);
        kamikazeBird.SetActive(false);
        }
        healthBar.SetSize(health);
        if (health <= 0)
        {
            gameOver.SetActive(true);
            player1.SetActive(false);
        }
    }
    public void Score()
    {
        score = score + 10;
    }
    public void HurtP1()
    {
        p1Life -= 1;
        for(int i = 0; i < p1Hearts.Length; i++)
        {
            if (p1Life > i)
            {
                p1Hearts[i].SetActive(true);
            }else
            {
                p1Hearts[i].SetActive(false);
            }
        }
        hurtSound.Play();

    }

}
