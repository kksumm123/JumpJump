using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] bool isGameOver = false;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (isGameOver)
        {

        }
    }

    public void SetIsGameOver(bool value)
    {
        isGameOver = value;
    }
}
