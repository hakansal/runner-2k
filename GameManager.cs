using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{ 

    public Transform _player;
    public TextMeshProUGUI _scror;
    public TextMeshProUGUI _highscror;
    public TextMeshProUGUI _lastscorre;
    public float score;
    float highscore;
    public ads _ads;
    public GameObject secbutton;
    public GameObject thanksbutton;
    void Start()
    {
        highscore = PlayerPrefs.GetFloat("s",0);
  
    }
    void Update()
    {
        score = _player.transform.position.x;
        _scror.SetText(score.ToString());
         
    }  
    void checkscore()
    {
        if (PlayerPrefs.HasKey("s") == false) Setscore(score);
        if (score > highscore) { Setscore(score); }
        _lastscorre.SetText("your score: " + score.ToString());
        _highscror.SetText("high score: " + PlayerPrefs.GetFloat("s"));

    }
    public void whendown()
    {
        Debug.Log("whendown wokr");
          
        checkscore();
        Time.timeScale = 0f;
        secbutton.SetActive(true);
        thanksbutton.SetActive(true);
       
    }
    public void nothanks()
    {
        SceneManager.LoadScene("scene2k");
        Time.timeScale = 1f;
    }
    void Setscore(float score)
    {
        PlayerPrefs.SetFloat("s", score);
    }
    


    
   



}

