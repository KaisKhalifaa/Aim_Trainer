using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] public float _mouseSensitivity = 2f;
    float _maxYAngle = 80f;
    float _rotationX = 0;
    void Start()
    {
        
    }

    void Update()
    {
        LookWithMouse();
    }

    void LookWithMouse()
    {
        float _mouseX=Input.GetAxis("Mouse X");
        float _mouseY=Input.GetAxis("Mouse Y");
        transform.Rotate(0,_mouseX * _mouseSensitivity,0);
        _rotationX -= _mouseY * _mouseSensitivity;
        _rotationX = Mathf.Clamp(_rotationX, -_maxYAngle, _maxYAngle);
        transform.localRotation = Quaternion.Euler(_rotationX, transform.localEulerAngles.y, 0);
    }
}
