using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public int player1;
    public int player2;
    public GameObject[] playerSpawner1;
    public GameObject[] playerSpawner2;
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
}
