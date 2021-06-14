using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] internal bool isGameOver = false;
    [SerializeField] internal bool isGameStart = false;
    [SerializeField] Transform[] SetActiveList;
    [SerializeField] Transform noticeUI;
    [SerializeField] Transform gamaOverUI;
    [SerializeField] Transform scoreUI;
    [SerializeField] Text scoreUIText;
    [SerializeField] int score;

    private void Awake()
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
            SetIsGameStart(false);
            if (Input.GetMouseButton(0))
                SceneManager.LoadScene(0);
        }
        else if (isGameStart)
        {
            UpdateScore();
            SurvivePoint();
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                foreach (var item in SetActiveList)
                {
                    item.gameObject.SetActive(true);
                }
                Player.instance.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                noticeUI.gameObject.SetActive(false);
                scoreUI.gameObject.SetActive(true);
                SetIsGameStart(true);
            }
        }
    }
    public void SetIsGameOver(bool value)
    {
        isGameOver = value;
    }
    public void SetIsGameStart(bool value)
    {
        isGameStart = value;
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
