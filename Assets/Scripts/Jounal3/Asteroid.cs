using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed = 1;
    public float arrivalDistance;
    public float maxFloatDistance = 2f;

    public float directionAngle;
    public Vector2 direction;
    public Vector2 startPosition;

    public bool targetDecided;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (!targetDecided)
        {
            startPosition = transform.position;
            targetDecided = true;

            maxFloatDistance = (UnityEngine.Random.Range(0, 200)/50f);
            directionAngle = UnityEngine.Random.Range(0, 360);

            direction = new Vector2(math.cos(directionAngle) * maxFloatDistance, math.sin(directionAngle) * maxFloatDistance);

        }

        arrivalDistance = Vector2.Distance(startPosition, transform.position);
        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;

        if (arrivalDistance >= maxFloatDistance)
        {
            targetDecided = false;
        }

    }
}
