using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaWave : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    [SerializeField] float speedAcceleration = 0.1f;
    [SerializeField] float speedLimit = 4.5f;
    void Update()
    {
        var pos = transform.position;
        pos.y += speed * Time.deltaTime;
        transform.position = pos;
        speed += speedAcceleration * Time.deltaTime;
        speed = Mathf.Min(speed, speedLimit);
    }
}
