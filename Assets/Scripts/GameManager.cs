using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform playerPaddle;
    public Transform enemyPaddle;

    public BallMovement ballMovement;

    private bool pointMade;
    public float resetTime = 3f;

    public int playerScore = 0;
    public int enemyScore = 0;

    public TextMeshProUGUI textPointsPlayer;
    public TextMeshProUGUI textPointsEnemy;

    public TextMeshProUGUI textEndGame;

    public GameObject screenEndGame;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        Invoke(nameof(ResetGame), resetTime);
    }

    public void ResetGame()
    {
        if (playerScore == 6 || enemyScore == 6)
        {
            CheckWin();
        }
        else
        {

            pointMade = true;
            playerPaddle.position = new Vector3(8f, 0f, 0f);
            enemyPaddle.position = new Vector3(-8f, 0f, 0f);

            ballMovement.ResetBall();
        }
    }

    public void PointMade()
    {
        if (pointMade)
        {
            ballMovement.gameObject.SetActive(false);
            Invoke(nameof(ResetGame), resetTime);
            pointMade = false;
        }
    }

    public void ScorePlayer()
    {
        playerScore++;
        textPointsPlayer.text = playerScore.ToString();
    }

    public void ScoreEnemy()
    {
        enemyScore++;
        textPointsEnemy.text = enemyScore.ToString();
    }

    private void CheckWin()
    {
        Invoke(nameof(EndGame), 1f);
    }

    public void EndGame()
    {
        screenEndGame.SetActive(true);
        textEndGame.text = "Vitoria  " + SaveController.instance.GetName(playerScore > enemyScore);
        SaveController.instance.SaveWinner(SaveController.instance.GetName(playerScore > enemyScore));
        Invoke(nameof(LoadMenu), 4f);
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
