using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StoolSpawn : MonoBehaviour
{
    [SerializeField] bool isPlaying = true;
    [SerializeField] GameObject stool;
    float startPoxY = 0.5f;
    float addY = 2.5f;
    int Count = 1;
    [SerializeField] float randMinX = -3f;
    [SerializeField] float randMaxX = 3f;
    [SerializeField] float spawnDelay = 2f;

    IEnumerator Start()
    {
        Debug.Assert(stool != null, "GameManager Stool гр╢Г ╬х╣й");
        while (isPlaying)
        {
            yield return new WaitForSeconds(spawnDelay);

            Instantiate(stool
                , new Vector2(Random.Range(randMinX, randMaxX), startPoxY + (addY * (float)(Count - 1)))
                , stool.transform.rotation);
            Count++;
        }
    }

    private IEnumerator SpawnStoolCo()
    {
        yield return new WaitForSeconds(spawnDelay);

        Instantiate(stool
            , new Vector2(Random.Range(randMinX, randMaxX), startPoxY + (addY * (float)(Count - 1)))
            , stool.transform.rotation);
        Count++;
    }
}
