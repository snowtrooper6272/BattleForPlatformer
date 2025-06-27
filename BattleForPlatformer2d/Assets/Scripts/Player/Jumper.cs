using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _jumpForce;

    public bool IsPossibleJump { get; private set; }

    public void SetGrounded()
    {
        IsPossibleJump = true;
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce);
        IsPossibleJump = false;
    }
}
