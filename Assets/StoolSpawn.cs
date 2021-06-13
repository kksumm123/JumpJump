using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StoolSpawn : MonoBehaviour
{
    [SerializeField] bool isSpawn = true;
    [SerializeField] GameObject stool;
    float startPoxY = 0.5f;
    float addY = 2.5f;
    int Count = 1;
    [SerializeField] float randMinX = -3f;
    [SerializeField] float randMaxX = 3f;
    [SerializeField] float distancePlayer = 20f;
    Vector2 curGoPos;
    private void Start()
    {
        SpawnStoolMain();
    }
    void Update()
    {
        ChkIsSpawn();
        if (isSpawn)
            SpawnStoolMain(); 
    }

    private void ChkIsSpawn()
    {
        if (curGoPos.y - Player.instance.transform.position.y < distancePlayer)
            isSpawn = true;
        else
            isSpawn = false;
    }

    void SpawnStoolMain()
    {
        Debug.Assert(stool != null, "GameManager Stool гр╢Г ╬х╣й");
        var curGo = Instantiate(stool
            , new Vector2(Random.Range(randMinX, randMaxX), startPoxY + (addY * (float)(Count - 1)))
            , stool.transform.rotation);
        Count++;
        curGoPos = curGo.transform.position;
    }
}
