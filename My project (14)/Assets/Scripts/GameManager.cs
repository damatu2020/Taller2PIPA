using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public int score;

    private void start()
    {
        newGame();
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
    }
}
