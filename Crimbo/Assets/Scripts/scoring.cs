﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class scoring : MonoBehaviour
{
    //public int score;
    //public string playerName;
    //public string email;

    public int InputScore;
    public string InputName;
    public string InputEmail;

    public GameObject player1;
    public InputField PlayerName;
    public InputField Email;

    string CreateUserURL = "http://gamesuite.rf.gd/scores/InsertUser.php";

    // Start is called before the first frame update
    void Start()
    {        
        StartCoroutine(PostRequest(InputScore, InputName, InputEmail));
        InputScore = 0;
    }
    public void scoreUp()
    {
        InputScore = InputScore + Random.Range(1, 50);
    }
    // Update is called once per frame
    void Update()
    {
        if (player1.activeInHierarchy == true)
        {
            InputScore = InputScore + 1;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            writeData();
        }
    }

    public void NameField()
    {
        InputName = PlayerName.text;
    }

    public void EmailField()
    {
        InputEmail = Email.text;
    }
    void writeData()
    {

    }
 /*   IEnumerator Upload()
    {
        //first create data or in the form of form data
        WWWForm form = new WWWForm();

        //add fields to the form
        form.AddField("score", InputScore);
        form.AddField("name", InputName);
        form.AddField("email", InputEmail);

        //create object for UnityWebRequest class from unityengine.networking 
        UnityWebRequest www = UnityWebRequest.Post(CreateUserURL, form);

        //always should return in IEnumerator
        yield return www.Send();
        //check if API is valid
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        //if is valid
        else
        {
            Debug.Log("Form upload complete!");
        }
    }*/

    IEnumerator PostRequest(int InputScore, string InputName, string InputEmail)
    {
        WWWForm form = new WWWForm();
        form.AddField("score", InputScore);
        form.AddField("name", InputName);
        form.AddField("email", InputEmail);

        using (UnityWebRequest uwr = UnityWebRequest.Post("http://gamesuite.rf.gd/scores/InsertUser.php", form))
        {


            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError)
            {
                Debug.Log("Error While Sending: " + uwr.error);
            }
            else
            {
                Debug.Log("Received: " + uwr.downloadHandler.text);
            }
        }    
    }

    /*   public void WriteScore(int score, string name, string email)
       {
               WWWForm form = new WWWForm();
               form.AddField("score", score);
               form.AddField("name", name);
               form.AddField("email", email);

               UnityWebRequest www = UnityWebRequest.Post(CreateUserURL, form);

               www.SendWebRequest();
               if (www.isNetworkError || www.isHttpError)
               {
                   Debug.Log(www.error);
               }
               else
               {
                   Debug.Log("Form upload complete!");
               }
       }*/

}
