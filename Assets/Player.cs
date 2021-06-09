using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 0.1f;
    Transform tr;

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

    private void Start()
    {
        tr = GetComponent<Transform>();
    }
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {

        }
    }
}
