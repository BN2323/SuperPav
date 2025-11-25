using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Sprites")]
    public Sprite unknown;
    public Sprite[] choices;

    [Header("UI")]
    public Image player1Image;
    public Image player2Image;
    public TextMeshProUGUI resultText, score1Text, score2Text;

    [Header("Health")]
    public Healthbar playerHealth;
    public Healthbar aiHealth;

    [Header("Effects")]
    public UIEffects effects;

    [Header("UI Screens")]
    public GameObject gameOverScreen;
    public GameObject winScreen;

    [Header("Points")]
    public int point = 25;

    int p1Score, p2Score;
    int p1Choice, p2Choice;

    AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();

        player1Image.sprite = unknown;
        player2Image.sprite = unknown;
        player2Image.rectTransform.localScale = Vector3.one;
    }

    public void SelectChoice(int choice)
    {
        audioManager.PlaySfx(audioManager.pav);

        p1Choice = choice;
        player1Image.sprite = choices[p1Choice];

        p2Choice = Random.Range(0, 3);
        player2Image.sprite = choices[p2Choice];
        player2Image.rectTransform.localScale = new Vector3(-1, 1, 1);

        StartCoroutine(effects.PunchScale(player1Image.transform));
        StartCoroutine(effects.ShakeUI(player1Image.rectTransform));

        StartCoroutine(effects.PunchScale(player2Image.transform));
        StartCoroutine(effects.ShakeUI(player2Image.rectTransform));

        CheckResult();
    }

    void CheckResult()
    {
        if (p1Choice == p2Choice)
        {
            resultText.text = "It's a tie!";
            return;
        }

        bool playerWins =
            (p1Choice == 0 && p2Choice == 2) ||
            (p1Choice == 1 && p2Choice == 0) ||
            (p1Choice == 2 && p2Choice == 1);

        if (playerWins)
        {
            resultText.text = "Player Wins!";
            aiHealth.TakeDamage(point);
            p1Score += point;
            score1Text.text = p1Score.ToString();
        }
        else
        {
            resultText.text = "AI Wins!";
            playerHealth.TakeDamage(point);
            p2Score += point;
            score2Text.text = p2Score.ToString();
        }

        CheckGameOver();
    }

    void CheckGameOver()
    {
        if (playerHealth.isDead)
        {
            gameOverScreen.SetActive(true);
            audioManager.PlaySfx(audioManager.aiWin);
        }
        else if (aiHealth.isDead)
        {
            winScreen.SetActive(true);
            audioManager.PlaySfx(audioManager.playeWin);
        }
    }
}
