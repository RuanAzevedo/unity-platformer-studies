using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    Sprite _defaultSprite;
    Rigidbody2D _rigidbody;
    AudioSource _audioSource;
    int _jumpsRemaining;

    [SerializeField] int _jumps = 2;
    [SerializeField] float _jumpDelay = 3;
    [SerializeField] Vector2 _jumpForce;
    [SerializeField] Sprite _jumpSprite;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultSprite = _spriteRenderer.sprite;
        _rigidbody = GetComponent<Rigidbody2D>();
        _jumpsRemaining = _jumps;
        _audioSource = GetComponent<AudioSource>();

        InvokeRepeating("Jump", _jumpDelay, _jumpDelay);
    }

    void Jump()
    {
        if (_jumpsRemaining <= 0)
        {
            _jumpForce *= new Vector2(-1, 1);
            _jumpsRemaining = _jumps;
        }
        _jumpsRemaining--;

        _rigidbody.AddForce(_jumpForce);

        _spriteRenderer.flipX = _jumpForce.x > 0;
        _spriteRenderer.sprite = _jumpSprite;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        _spriteRenderer.sprite = _defaultSprite;
        _audioSource.Play();
    }
}
