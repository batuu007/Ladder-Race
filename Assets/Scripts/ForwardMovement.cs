using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForwardMovement : Singleton<ForwardMovement>
{
    [SerializeField] private float _moveSpeed;
    public bool _canMove = true;

    private void Update()
    {
        if (_canMove)
        {
            Movement();
        }
    }

    private void Movement()
    {
        transform.Translate(Vector3.forward*_moveSpeed*Time.deltaTime);
    }
}
