using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private KeyCode _jumpKey;
    [SerializeField] private KeyCode _attackKey;
    [SerializeField] private float _frequency;

    private float _currentFrequency;
    private string _moveAxis = "Horizontal";

    public event Action Attacked; 

    public float AxisDirection { get; private set; }
    public bool IsJumpKeyDown { get; private set; }

    private void Update()
    {
        if (Input.GetKeyDown(_jumpKey))
            IsJumpKeyDown = true;

        if (_currentFrequency >= _frequency)
        {
            if (Input.GetKeyDown(_attackKey))
            {
                Attacked.Invoke();
                _currentFrequency = 0;
            }
        }
        else 
        {
            _currentFrequency += Time.deltaTime;
        }

        AxisDirection = Input.GetAxis(_moveAxis);
    }

    public void Jump() 
    {
        IsJumpKeyDown = false;
    }
}
