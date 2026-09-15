using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;

    public int numberOfBombs;
    public Vector2 bombSpacing = new Vector2 (0, -1);

    //public Vector3 bombOffset = new Vector3(0, 1, 0);

    void Start()
    {
        Debug.Log(normalize(new Vector2(1.5f, -3.5f)));
        numberOfBombs = 5;
    }

    void Update()
    {
        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            StartCoroutine(SpawnBombAtOffset(Vector2.down, numberOfBombs, bombSpacing));
        }
        else if (Keyboard.current.bKey.isPressed == false)
        {
        }
    }


    IEnumerator SpawnBombAtOffset(Vector2 inOffset, int numberofbombs, Vector2 bombSpacing)
    {
        for (int i = 0; i < numberofbombs; i++)
        {
            Instantiate(bombPrefab, transform.position + (Vector3) inOffset, Quaternion.identity);
            inOffset += bombSpacing;
            yield return new WaitForSeconds(0.1f);
        }
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
