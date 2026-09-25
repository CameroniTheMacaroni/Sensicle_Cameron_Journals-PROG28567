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
        moveSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!targetDecided)
        {
            startPosition = transform.position;//track the starting position
            targetDecided = true;

            maxFloatDistance = (UnityEngine.Random.Range(0, 200)/50f);//randomly decide on how far the asteroid should go
            directionAngle = UnityEngine.Random.Range(0, 360);//randomly decide on the angle of the direction the asteroid should go in

            direction = new Vector2(math.cos(directionAngle) * maxFloatDistance, math.sin(directionAngle) * maxFloatDistance);//calculate the direction with the angle

        }

        arrivalDistance = Vector2.Distance(startPosition, transform.position);//track how far the asteroid has moved
        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;//update the asteroid's position

        if (arrivalDistance >= maxFloatDistance)//if the asteroid has reached its destination... 
        {
            targetDecided = false;//... decide on a new point
        }

    }
}
