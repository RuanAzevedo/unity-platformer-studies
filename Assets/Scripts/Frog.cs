using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    Rigidbody2D _rigidbody;

    [SerializeField] float _jumpDelay = 3;
    [SerializeField] Vector2 _jumpForce;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        InvokeRepeating("Jump", _jumpDelay, _jumpDelay);
    }

    void Jump()
    {
        _rigidbody.AddForce(_jumpForce);
    }
}
