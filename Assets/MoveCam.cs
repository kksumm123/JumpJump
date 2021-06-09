using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    [SerializeField] float camDistanceOffset;
    [SerializeField] float speed = 5f;
    Transform player;
    void Start()
    { 
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        camDistanceOffset = Mathf.Abs(transform.position.y - player.position.y);
        Debug.Assert(player != null, "�÷��̾� �Ҵ� ����");
    }

    void Update()
    {
        var distanceBetweenPlayerY = camDistanceOffset - (transform.position.y - player.position.y);
        Debug.Log(distanceBetweenPlayerY);
        transform.Translate(new Vector3(0, distanceBetweenPlayerY * speed * Time.deltaTime, 0));
    }
}
