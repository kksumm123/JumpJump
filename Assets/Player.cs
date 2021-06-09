using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 0.1f;
    Transform tr;
    Vector2 size;

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
        tr = GetComponent<Transform>();
        size = GetComponent<BoxCollider2D>().size;
        SetWallLayer();
    }
    void Update()
    {
        SetCurrentState();
        if (Input.GetKey(KeyCode.A))
        {

        }
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
        if (ChkGround3DirRay(tr.position - new Vector3(size.x / 2, 0, 0)))
            return true;
        if (ChkGround3DirRay(tr.position))
            return true;
        if (ChkGround3DirRay(tr.position + new Vector3(size.x / 2, 0, 0)))
            return true;

        return false;
    }

    private bool ChkGround3DirRay(Vector3 position)
    {
        Debug.Assert(groundLayer != 0, "그라운드 레이어 설정 안됨");
        var hit = Physics2D.Raycast(position, Vector2.down, size.y / 2 + 0.1f, groundLayer);
        return hit.transform;
    }
}
