using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoring : MonoBehaviour
{

    const string privateCode = "tE096hAKYEumPdA8PH2QnwHDr9lgXnrEC76Dne529EuA";
    const string publicCode = "5dcf386cb5622e683c2089ec";
    const string webURL = "http://dreamlo.com/lb/";

    public Highscore[] highscoresList;

    public int score;
    public new string name;
    public InputField PlayerName;
    public Text uiText;

    private void Update()
    {
        uiText.text = score.ToString();
    }
    public void NameField()
    {
        name = PlayerName.text;
    }

    public void WriteScore()
    {

        AddNewHighscore(name, score);

        DownloadHighscores();
    }

    public void AddNewHighscore(string username, int score)
    {
        StartCoroutine(UploadNewHighscore(username, score));
    }

    IEnumerator UploadNewHighscore(string username, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
            print("Upload Successful");
        else
        {
            print("Error uploading: " + www.error);
        }
    }

    public void DownloadHighscores()
    {
        StartCoroutine("DownloadHighscoresFromDatabase");
    }

    IEnumerator DownloadHighscoresFromDatabase()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
            FormatHighscores(www.text);
        else
        {
            print("Error Downloading: " + www.error);
        }
    }

    void FormatHighscores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new Highscore[entries.Length];

        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoresList[i] = new Highscore(username, score);
            print(highscoresList[i].username + ": " + highscoresList[i].score);
        }
    }
    public void ScoreUp()
    {
        score += Random.Range(1, 50);
    }
}

public struct Highscore
{
    public string username;
    public int score;

    public Highscore(string _username, int _score)
    {
        username = _username;
        score = _score;
    }


}