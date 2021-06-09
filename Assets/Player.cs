using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    Transform tr;
    Rigidbody2D rigid;
    BoxCollider2D col;

    #region StateType
    [SerializeField] StateType state;
    StateType State
    {
        get { return state; }
        set
        {
            Debug.Log($"{state} -> {value}");
            state = value;
        }
    }
    enum StateType
    {
        Ground,
        Jump,
        Fall
    }
    #endregion

    private void Start()
    {
        Application.targetFrameRate = 60;
        tr = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        SetWallLayer();
    }
    void FixedUpdate()
    {
        SetCurrentState();
        Move();
        Jump();
    }
    [SerializeField] float forceY = 900;
    private void Jump()
    {
        if (State == StateType.Ground)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                State = StateType.Jump;
                rigid.AddForce(new Vector2(0, forceY));
            }
        }
    }

    private void Move()
    {
        if (State == StateType.Ground)
            return;

        var pos = tr.position;
        int dir = 0;
        if (Input.GetKey(KeyCode.A))
            dir = -1;
        if (Input.GetKey(KeyCode.D))
            dir = 1;

        pos.x += dir * speed * Time.fixedDeltaTime;

        tr.position = pos;
    }

    LayerMask groundLayer;
    void SetWallLayer()
    {
        groundLayer = 1 << LayerMask.NameToLayer("Ground");
    }
    private void SetCurrentState()
    {
        if (ChkGround())
            State = StateType.Ground;
    }

    bool ChkGround()
    {
        if (ChkGround3DirRay(tr.position - new Vector3(col.size.x / 2, 0, 0)))
            return true;
        if (ChkGround3DirRay(tr.position))
            return true;
        if (ChkGround3DirRay(tr.position + new Vector3(col.size.x / 2, 0, 0)))
            return true;

        return false;
    }

    [SerializeField] float raycastOffset = 0.02f;
    private bool ChkGround3DirRay(Vector3 position)
    {
        Debug.Assert(groundLayer != 0, "그라운드 레이어 설정 안됨");
        var hit = Physics2D.Raycast(position, Vector2.down, col.size.y / 2 + raycastOffset, groundLayer);
        return hit.transform;
    }
}
