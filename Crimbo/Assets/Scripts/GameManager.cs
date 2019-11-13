using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //private GameObject Player1;
    //private GameObject Player2;
    public GameObject player1Win;
    public GameObject player2Win;
    public GameObject[] p1Rocks;
    public GameObject[] p2Rocks;
    public AudioSource hurtSound;
    public GameObject dimLight;

    public string mainMenu;

    public int p1Life;
    public int p2Life;

    public GameObject Player1;
    public GameObject Player2;
    public int player1;
    public int player2;
    public GameObject[]playerSpawner1;
    public GameObject[]playerSpawner2;
    public Transform spawnpoint1;
    public Transform spawnpoint2;

    // Start is called before the first frame update
    void Start()
    {
        player1 = PlayerPrefs.GetInt("Player1Spawn");
        player2 = PlayerPrefs.GetInt("Player2Spawn");
        GameObject Player1 = (GameObject)Instantiate(playerSpawner1[player1], spawnpoint1.position, spawnpoint1.rotation);
        GameObject Player2 = (GameObject)Instantiate(playerSpawner2[player2], spawnpoint2.position, spawnpoint2.rotation);
    }

    // Update is called once per frame
    void Update()
    {

        Player1 = GameObject.FindWithTag("Player1");
        Player2 = GameObject.FindWithTag("Player2");
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(mainMenu);
        }
        if (p1Life <= 0)
        {
            Player1.SetActive(false);
            player2Win.SetActive(true);
            dimLight.SetActive(true);
        }
        if (p2Life <= 0)
        {
            Player2.SetActive(false);
            player1Win.SetActive(true);
            dimLight.SetActive(true);
        }
    }
    public void Shield()
    {
        if (tag == "Player1")
        {
            p1Life = p1Life + 5;
        }
        if (tag == "Player2")
        {
            p2Life = p2Life + 5;
        }
    }
    public void HurtP1()
    {
        p1Life -= 1;


        if (p1Life == 4)
        {
            p1Rocks[4].SetActive(false);
        }else if(p1Life == 3)
        {
            p1Rocks[3].SetActive(false);
        }else if(p1Life == 2)
        {
            p1Rocks[2].SetActive(false);
        }else if(p1Life == 1)
        {
            p1Rocks[1].SetActive(false);
        }else if(p1Life == 0)
        {
            p1Rocks[0].SetActive(false);
        }
        hurtSound.Play();
            
    }
    public void HurtP2()
    {
        p2Life -= 1;


        if (p2Life == 4)
        {
            p2Rocks[4].SetActive(false);
        }
        else if (p2Life == 3)
        {
            p2Rocks[3].SetActive(false);
        }
        else if (p2Life == 2)
        {
            p2Rocks[2].SetActive(false);
        }
        else if (p2Life == 1)
        {
            p2Rocks[1].SetActive(false);
        }
        else if (p2Life == 0)
        {
            p2Rocks[0].SetActive(false);
        }
        hurtSound.Play();
    }
}
