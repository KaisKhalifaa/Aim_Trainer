using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController _playerController;
    private Transform _playerCameraTransform;
    private Vector3 _velocity;
    float _moveSpeed = 7f;

    void Start(){
        _playerController = GetComponent<CharacterController>();
        _playerCameraTransform=Camera.main.transform;
    }
    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer(){
        Vector3 _forward = _playerCameraTransform.forward;
        _forward.y=0;
        _forward.Normalize();

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = (_forward * verticalInput + _playerCameraTransform.right*horizontalInput).normalized;
        _playerController.Move(moveDirection * _moveSpeed * Time.deltaTime);
    }
}