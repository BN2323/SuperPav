using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Sprite unknown;
    public Sprite[] choices;
    public GameObject player1, player2;
    public TextMeshProUGUI resultText, Score1, Score2;
    int player1Score = 0, player2Score = 0;
    public int point = 25;
    AudioManager audioManager;
    [SerializeField] GameObject gameOver, gameWin;
    [SerializeField] Healthbar playerHealthbar, aiHealthbar;

    private int player1Choice;
    private int player2Choice;
    void Start()
    {
        player1.GetComponent<Image>().sprite = unknown;
        player2.GetComponent<Image>().sprite = unknown;
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }

    public void SelectChoice(int choice)
    {
        audioManager.PlaySfx(audioManager.pav);
        player1.GetComponent<Image>().sprite = choices[choice];
        player1Choice = choice;
        int randomInt = Random.Range(0, 3);
        player2.GetComponent<Image>().sprite = choices[randomInt];
        player2Choice = randomInt;
        DetermineWinner();
    }

    void DetermineWinner()
    {
        if (player1Choice == player2Choice)
        {
            resultText.text = "It's a tie!";
        }
        else if ((player1Choice == 0 && player2Choice == 2) ||
                 (player1Choice == 1 && player2Choice == 0) ||
                 (player1Choice == 2 && player2Choice == 1))
        {
            resultText.text = "Player 1 wins!";
            aiHealthbar.TakeDamage(point);
            player1Score += point;
            Score1.text = player1Score.ToString();
        }
        else
        {
            resultText.text = "Player 2 wins!";
            playerHealthbar.TakeDamage(point);
            player2Score += point;
            Score2.text = player2Score.ToString();
        }

        if(playerHealthbar.isDead)
        {
            if (gameOver)
            {
                gameOver.SetActive(true);
                audioManager.PlaySfx(audioManager.aiWin);
            }
        }else if(aiHealthbar.isDead)
        {
            if (gameWin)
            {
                gameWin.SetActive(true);
                audioManager.PlaySfx(audioManager.playeWin);
            }
        }
    }
}
