using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public int puntajeActual;
    public int puntajeMax;

    void Start()
    {
        newGame();
        loadPuntMax();
    }

    private void loadPuntMax(){
        puntajeMax = PlayerPrefs.GetInt("puntajeMax");
    }

    private void newGame()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    public void increaseScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
        PlayerPrefs.SetInt("puntajeActual", score);
        if(score > puntajeMax){
            PlayerPrefs.SetInt("puntajeMax", score);
            puntajeMax = score;
        }
    }
    
}
