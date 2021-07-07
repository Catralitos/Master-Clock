using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour
{
    public bool clockwise;
    public float angularSpeed = 1f;
    public float circleRad = 1f;

    
    public Transform fixedPoint;
    
    private float _currentAngle;

    private void Start()
    {
        if (!clockwise) angularSpeed *= -1;
    }

    void Update()
    {
        _currentAngle += angularSpeed * Time.deltaTime;
        Vector2 offset = new Vector2(Mathf.Sin(_currentAngle), Mathf.Cos(_currentAngle)) * circleRad;
        transform.position = (Vector2) fixedPoint.position + offset;
    }
}