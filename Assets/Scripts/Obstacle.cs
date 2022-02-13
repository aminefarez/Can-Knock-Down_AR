using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
    // This Script is used to move the Obstacles in the Level 3
{
    public float Shift = 1.5f;  // Amount to move left and right from the start point
    public float Speed = 2.0f;  // Speed of the movement
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Shift the Obstacle from the initial position
        Vector3 v = startPos;
        v.x += Shift * Mathf.Sin(Time.time * Speed);
        transform.position = v;
    }
}