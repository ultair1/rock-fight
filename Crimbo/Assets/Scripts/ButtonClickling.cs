using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ButtonClickling : MonoBehaviour
{
    private int player1SpawnIndex;
    private int player2SpawnIndex;

    public string loadedLevel; //corresponds to the next level, where the characters will be spawned

    public void Ian()//can be written as "character1_player1" and so forth, but the characters have names in this game
    {
        player1SpawnIndex = 0;//these numbers just mean a position in an array defined in the other script in this system
    }
    public void Krillin()
    {
        player1SpawnIndex = 2;
    }
    public void Negative()
    {
        player1SpawnIndex = 3;
    }
    public void Derrick()
    {
        player1SpawnIndex = 1;
    }
    public void Ian2()//can be written as "character1_player2" and so forth, but the characters have names in this game
    {
        player2SpawnIndex = 0;
    }
    public void Krillin2()
    {
        player2SpawnIndex = 2;
    }
    public void Negative2()
    {
        player2SpawnIndex = 3;
    }
    public void Derrick2()
    {
        player2SpawnIndex = 1;
    }
    public void lockIn()
    {
        PlayerPrefs.SetInt("Player1Spawn", player1SpawnIndex);
        PlayerPrefs.SetInt("Player2Spawn", player2SpawnIndex);
    }
    public void loadGame()
    {
        SceneManager.LoadScene(loadedLevel);
    }
}