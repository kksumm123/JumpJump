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
        SetPlayer();
    }

    void Update()
    {
        if (player == null)
            SetPlayer();

        var distanceBetweenPlayerY = camDistanceOffset - (transform.position.y - player.position.y);
        transform.Translate(new Vector3(0, distanceBetweenPlayerY * speed * Time.deltaTime, 0));
    }
    private void SetPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        camDistanceOffset = Mathf.Abs(transform.position.y - player.position.y);
        Debug.Assert(player != null, "플레이어 할당 실패");
    }
}
