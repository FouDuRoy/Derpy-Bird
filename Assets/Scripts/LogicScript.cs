using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int highScore;
    public TextMeshProUGUI scorePts;
    public TextMeshProUGUI highScorePts;
    public GameObject gameOverScreen;

    [ContextMenu("Increase Score")]

    private void Start()
    {
        highScorePts.text = PlayerPrefs.GetInt("HighScore").ToString();
        highScore = PlayerPrefs.GetInt("HighScore");
    }


    public void addScore()
    {
        playerScore++;
        if(playerScore > highScore)
        {
            highScore++;
            highScorePts.text = highScore.ToString();
        }
        scorePts.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        if (playerScore > PlayerPrefs.GetInt("HighScore"))
        PlayerPrefs.SetInt("HighScore", highScore);

        gameOverScreen.SetActive(true);
    }

}
