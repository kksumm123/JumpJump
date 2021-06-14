using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stool : MonoBehaviour
{
    bool isHit = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if(isHit == false)
            {
                isHit = true;
                GameManager.instance.GetScore(10);
            }
        }
    }
}
