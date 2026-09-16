using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;

    public int numberOfBombs;
    public Vector2 bombSpacing = new Vector2 (0, -1);

    public float cornerSpawnDistance;

    public float teleportRatio;

    //public Vector3 bombOffset = new Vector3(0, 1, 0);

    void Start()
    {
        Debug.Log(normalize(new Vector2(1.5f, -3.5f)));
        numberOfBombs = 8;
    }

    void Update()
    {
        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            StartCoroutine(SpawnBombAtOffset(Vector2.down, numberOfBombs, bombSpacing));
        }
        if (Keyboard.current.nKey.wasPressedThisFrame)
        {
            cornerSpawn(cornerSpawnDistance);
        }
        if (Keyboard.current.mKey.wasPressedThisFrame)
        {
            teleport(enemyTransform, teleportRatio);
        }

        radars();
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

    public void cornerSpawn(float inDistance)
    {
        float distance = inDistance * math.cos(45);
        Instantiate(bombPrefab, transform.position + new Vector3(flipACoin(inDistance), flipACoin(inDistance), 0), Quaternion.identity);
        
    }
    
    public float flipACoin(float coin)
    {
        int x = UnityEngine.Random.Range(0, 2);
        if(x == 1)
        {
            coin = coin * -1;
        }
        return coin;
    }
   
    public void teleport(Transform target, float ratio)
    {
        float distance = Vector2.Distance(target.transform.position, transform.position);
        
        Vector2 direction = target.transform.position - transform.position;

        direction = direction.normalized;
        Debug.Log(direction + " " + distance);

        transform.position += (Vector3)(direction * (distance * ratio));

        //Debug.DrawLine(transform.position, direction);
    }

    public void radars()
    {
        for (int i = 0; i < asteroidTransforms.Count; i++)
        {
            if(Vector2.Distance(asteroidTransforms[i].transform.position, transform.position) > 2.5)
            {

            }
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
