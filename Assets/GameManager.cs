using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] internal bool isGameOver = false;
    [SerializeField] Transform gamaOverUI;
    [SerializeField] Transform scoreUI;
    [SerializeField] Text scoreUIText;
    [SerializeField] int score;

    private void Start()
    {
        instance = this;
        gamaOverUI.gameObject.SetActive(false);
        scoreUIText = scoreUI.GetComponentInChildren<Text>();
    }

    private void Update()
    {
        if (isGameOver)
        {
            gamaOverUI.gameObject.SetActive(true);
            if (Input.GetMouseButton(0))
                SceneManager.LoadScene(0);
        }
        else
        {
            UpdateScore();
            SurvivePoint();
        }
    }
    public void SetIsGameOver(bool value)
    {
        isGameOver = value;
    }
    public void GetScore(int value)
    {
        score += value;
    }
    void UpdateScore()
    {
        scoreUIText.text = "Score : " + score;
    }
    void SurvivePoint()
    {
        score++;
    }
}
