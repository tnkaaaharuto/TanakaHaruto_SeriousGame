using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;

public class UIController : MonoBehaviour
{
    GameObject Backpad, Pad;
    GameObject Timer, Score;
    GameObject Player;
    GameObject Restart;
    public float time = 60.0f;
    float countdown = 3.0f;
    bool Fin = false;

    private void Start()
    {
        Backpad = GameObject.Find("BackPad");
        Pad = GameObject.Find("Pad");
        Timer = GameObject.Find("Time");
        Score = GameObject.Find("Score");
        Player = GameObject.Find("Player");
        Restart = GameObject.Find("Restart");
    }
    private void Update()
    {
        if (countdown <= 0 && !Fin)
        {
            time -= Time.deltaTime;
            Timer.GetComponent<TextMeshProUGUI>().text = time.ToString("F1");
            if(time <= 0)
            {
                Fin = true;
                Score.GetComponent<TextMeshProUGUI>().enabled = true;
                Score.GetComponent<TextMeshProUGUI>().fontSize = 70;
                Score.GetComponent<TextMeshProUGUI>().text = "TimeUp";
                Player.GetComponent<Player>().EndGame();
            }
        }
        else if(!Fin)
        {
            countdown -= Time.deltaTime;
            Score.GetComponent<TextMeshProUGUI>().text = Mathf.Ceil(countdown).ToString("n0");
            if (countdown <= 0)
            {
                Score.GetComponent<TextMeshProUGUI>().enabled = false;
                Player.GetComponent<Player>().StartGame();
            }
        }
    }

    public void VisibleController(Vector2 Pos, Vector2 sPos)
    {
        Backpad.GetComponent<Image>().enabled = true;
        Pad.GetComponent<Image>().enabled = true;
        Backpad.GetComponent<RectTransform>().anchoredPosition = sPos;
        Pad.GetComponent<RectTransform>().anchoredPosition = Pos;
    }
    public void UnVisibleController()
    {
        Backpad.GetComponent<Image>().enabled = false;
        Pad.GetComponent<Image>().enabled = false;
    }


    public void StageClear(int hit)
    {
        int scorePoint = 0;
        scorePoint = GameObject.Find("ScoreManager").GetComponent<ScoreManager>().Score(time,hit);
        string text = "Score\n" + scorePoint.ToString();
        if (GameObject.Find("ScoreManager").GetComponent<ScoreManager>().HighScore(scorePoint))
        {
            text ="HighScore\n" + scorePoint.ToString();
        }
        
        Score.GetComponent<TextMeshProUGUI>().enabled = true;
        Score.GetComponent<TextMeshProUGUI>().fontSize = 60;
        Score.GetComponent<TextMeshProUGUI>().text = text;
        Fin = true;
    }

    public void RestartButton()
    {
        Restart.GetComponent<Canvas>().enabled = true;
    }
}
