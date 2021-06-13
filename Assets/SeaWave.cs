using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaWave : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    void Update()
    {
        var pos = transform.position;
        pos.y += speed * Time.deltaTime;
        transform.position = pos;
    }
}
