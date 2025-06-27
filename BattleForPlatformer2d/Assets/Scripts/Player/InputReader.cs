using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public float AxisDirection { get; private set; }
    public bool IsJumpKeyDown { get; private set; }

    private string _moveAxis = "Horizontal";
    private KeyCode _jumpKey = KeyCode.Space;

    private void Update()
    {
        if (Input.GetKeyDown(_jumpKey))
            IsJumpKeyDown = true;

        AxisDirection = Input.GetAxis(_moveAxis);
    }

    public void Jump() 
    {
        IsJumpKeyDown = false;
    }
}
