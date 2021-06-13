using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    [SerializeField] float distancePlayer = 130f;
    Transform tr;
    SpriteRenderer sprite;
    [SerializeField] float width;
    private void Start()
    {
        tr = transform;
        sprite = GetComponentInChildren<SpriteRenderer>();
        width = sprite.size.x;
    }
    void Update()
    {
        if (Mathf.Abs(tr.position.y - Player.instance.transform.position.y) > distancePlayer)
        {
            var pos = tr.position;
            pos.y += width * 4;
            tr.position = pos;
        }
    }
}
