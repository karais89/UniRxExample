using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example08Player : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private CharacterController _characterController;
    private Vector3 _moveDirection = Vector3.zero;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        _moveDirection *= speed;

        if (Input.GetButton("Jump"))
        {
            _moveDirection.y = jumpSpeed;
        }
 
        _moveDirection.y -= gravity * Time.deltaTime;

        _characterController.Move(_moveDirection * Time.deltaTime);
    }
}
