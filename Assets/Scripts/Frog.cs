using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    Sprite _defaultSprite;
    Rigidbody2D _rigidbody;

    [SerializeField] float _jumpDelay = 3;
    [SerializeField] Vector2 _jumpForce;
    [SerializeField] Sprite _jumpSprite;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultSprite = _spriteRenderer.sprite;
        _rigidbody = GetComponent<Rigidbody2D>();

        InvokeRepeating("Jump", _jumpDelay, _jumpDelay);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        _spriteRenderer.sprite = _defaultSprite;
    }

    void Jump()
    {
        _rigidbody.AddForce(_jumpForce);
        _jumpForce *= new Vector2(-1, 1);
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
        _spriteRenderer.sprite = _jumpSprite;

    }
}
