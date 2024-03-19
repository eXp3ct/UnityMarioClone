using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerCollision))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)] private float _moveSpeed = 5f;
    [SerializeField, Range(0f, 20f)] private float _jumpForce = 10f;

    private Rigidbody2D _rigidBody;
    private PlayerInput _playerInput;
    private PlayerCollision _playerCollision;

    private bool _isGrounded;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        _playerCollision = GetComponent<PlayerCollision>();
    }
    private void Update()
    {  
        _isGrounded = _playerCollision.IsGrounded;
    }
    private void FixedUpdate()
    {
        Jump(_playerInput.JumpPressed);
        Move(_playerInput.MoveDirection);
    }

    private void Move(Vector2 moveDirection)
    {
        _rigidBody.velocity = new Vector2(moveDirection.x * _moveSpeed, _rigidBody.velocity.y);
    }

    private void Jump(bool jumpPressed)
    {
        Debug.Log($"Grounded: {_isGrounded} | JumpPressed: {jumpPressed}");
        if(_isGrounded && jumpPressed)
        {
            _rigidBody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
