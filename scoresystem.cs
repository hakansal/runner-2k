using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoresystem : MonoBehaviour
{
	string dreamloWebserviceURL = "http://dreamlo.com/lb/";

	public bool IUpgradedAndGotSSL = false;
	public string privateCode = "";
	public string publicCode = "";
	public highscore[] highscoreslist;
	public int _score;
	string playername;
    [System.Obsolete]
    public GameManager gamemanager;
	public string[] names;
	public int[] scores;

    [System.Obsolete]
    public void Start()
	{
		downloadhigscore(null);
		 
		 
	}

    [System.Obsolete]
    public void newscore(string name,int score)
	{
		 
		Adnewhighscore(name, score);
		 
	}

    [System.Obsolete]
    public void Adnewhighscore(string username, int score)
	{
		StartCoroutine(uploadhighscore(username, score));

	}

    [System.Obsolete]
    IEnumerator uploadhighscore(string username, int score)
	{
		WWW www = new WWW(dreamloWebserviceURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
		yield return www;

		 
		 
	}

    [System.Obsolete]
    public void downloadhigscore(string checknames)
	{

        StartCoroutine(downloadhighscore(checknames));
	}

    [System.Obsolete]
    IEnumerator downloadhighscore(string checknames)
	{
		WWW www = new WWW(dreamloWebserviceURL + publicCode + "/pipe/");
		yield return www;
		formatscores(www.text,  checknames);
	}

    [System.Obsolete]
    void formatscores(string textStream,string checknames)
    {
		string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
		highscoreslist = new highscore[entries.Length];

		for (int i = 0; i < entries.Length; i++)
		{
			string[] entryInfo = entries[i].Split(new char[] { '|' });
			string username = entryInfo[0];
			int score = int.Parse(entryInfo[1]);
			highscoreslist[i] = new highscore(username, score);
			 
			   if (checknames == highscoreslist[i].username) {
				 gamemanager.GetComponent<GameManager>().namebool = true;
				 
			    }
			   if (highscoreslist[i].username == PlayerPrefs.GetString("thenames"))
			   {
				_score = highscoreslist[i].score;
			   }
            if (i<names.Length)
            {
				names[i] = highscoreslist[i].username;
				scores[i] = highscoreslist[i].score;
			}
		}
        
	
	}
	public struct highscore
	{
		public string username;
		public int score;
		public highscore(string _username, int _score)
		{
			username = _username;
			score = _score;


		}
	}
}
