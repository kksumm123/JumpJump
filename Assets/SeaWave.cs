using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaWave : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    [SerializeField] float speedAcceleration = 0.1f;
    [SerializeField] float speedLowAcceleration = 0.005f;
    [SerializeField] float speedLimit = 4f;
    void Update()
    {
        if (GameManager.instance.isGameStart)
        {
            var pos = transform.position;
            pos.y += speed * Time.deltaTime;
            transform.position = pos;
            speed += (speed < 4 ? speedAcceleration : speedLowAcceleration) * Time.deltaTime;
        }
    }
}
