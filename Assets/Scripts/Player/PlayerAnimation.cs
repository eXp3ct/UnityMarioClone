using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private PlayerInput _playerInput;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        var moveDirection = _playerInput.MoveDirection;
        var isJumping = _playerInput.JumpPressed;

        _spriteRenderer.flipX = moveDirection.x < 0;

        _animator.SetBool("IsWalking", moveDirection != Vector2.zero);
        _animator.SetBool("IsJumping", isJumping);
    }
}
