using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 MoveDirection { get; private set; }
    public bool JumpPressed { get; private set; }

    private void Update()
    {
        MoveDirection = GetDirection();
    }
    private void FixedUpdate()
    {
        JumpPressed = Input.GetAxis("Jump") > 0;
    }
    private Vector2 GetDirection()
    {
        var moveX = Input.GetAxisRaw("Horizontal");

        return new Vector2(moveX, MoveDirection.y);
    }
}
