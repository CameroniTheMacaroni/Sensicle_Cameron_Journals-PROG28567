using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;

    //public Vector3 bombOffset = new Vector3(0, 1, 0);

    void Start()
    {
        Debug.Log(normalize(new Vector2(1.5f, -3.5f)));
    }

    void Update()
    {
        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            SpawnBombAtOffset(Vector3.up);
        }
        else if (Keyboard.current.bKey.isPressed == false)
        {
        }
    }

    public void SpawnBombAtOffset(Vector3 inOffset)
    {
        Instantiate(bombPrefab, transform.position + inOffset, Quaternion.identity);
    }

    public Vector2 normalize(Vector2 input)
    {
        Debug.Log("answer: " + input.normalized);
        float x;
        float y;

        x = input.x / Math.Abs(input.magnitude);
        y = input.y / Math.Abs(input.magnitude);

        input.x = x;
        input.y = y;

        return input;
    }
}
