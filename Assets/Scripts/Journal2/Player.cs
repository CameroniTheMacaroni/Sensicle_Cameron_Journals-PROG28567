using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
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
    public float maxRange = 2.5f;

    public float maxSpeed = 10;
    public float acceleration = 5;
    public float deceleration = 5;

    public Vector2 velocity;
    public Vector2 cancelMomentum;


    //public Vector3 bombOffset = new Vector3(0, 1, 0);

    void Start()
    {

    }

    void Update()
    {
        if (Keyboard.current.bKey.wasPressedThisFrame)//bomb trails
        {
            StartCoroutine(SpawnBombAtOffset(Vector2.down, numberOfBombs, bombSpacing));
        }
        if (Keyboard.current.nKey.wasPressedThisFrame)//corner bombs
        {
            cornerSpawn(cornerSpawnDistance);
        }
        if (Keyboard.current.mKey.wasPressedThisFrame)//warp drive
        {
            teleport(enemyTransform, teleportRatio);
        }

        radars(maxRange);//radars

        playerMovement();
    }


    public void playerMovement()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            velocity += acceleration * Time.deltaTime * Vector2.up;//add acceleration variable to speed with respect to time
        }
        if (Keyboard.current.dKey.isPressed)
        {
            velocity += acceleration * Time.deltaTime * Vector2.right;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            velocity += acceleration * Time.deltaTime * Vector2.down;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            velocity += acceleration * Time.deltaTime * Vector2.left;
        }

        //if theres no movement inputs
        if(Keyboard.current.wKey.isPressed == false && Keyboard.current.aKey.isPressed == false && Keyboard.current.sKey.isPressed == false && Keyboard.current.dKey.isPressed == false)
        {
            cancelMomentum = velocity.normalized;//normalize the velocity vector...

            if (velocity != Vector2.zero)//... and if the ship is still moving... 
            {
                velocity -= cancelMomentum * Time.deltaTime * deceleration;//... substact the normalized velocity vector from the velocity vector
            }
        }

        velocity = Vector2.ClampMagnitude(velocity, maxSpeed);//don't let the ship go too fast
        transform.position += (Vector3) velocity * Time.deltaTime;//update ship position

    }
   
    IEnumerator SpawnBombAtOffset(Vector2 inOffset, int numberofbombs, Vector2 bombSpacing)
    {
        Vector3 spawnPosition = transform.position;
        for (int i = 0; i < numberofbombs; i++)
        {
            //spawn bombs for each number of bombs specified
            Instantiate(bombPrefab, spawnPosition + (Vector3) inOffset, Quaternion.identity);//place them at the ship position + bomb spacing
            inOffset += bombSpacing;//increment the bomb spacing
            yield return new WaitForSeconds(0.1f);//wait a bit so that it looks cool
        }
    }

    public void cornerSpawn(float inDistance)
    {
        float distance = inDistance * math.cos(45);//find the distance for the bombs in the corner
        Instantiate(bombPrefab, transform.position + new Vector3(flipACoin(inDistance), flipACoin(inDistance), 0), Quaternion.identity);
        
    }
    
    public float flipACoin(float coin)//randomly invert the sign of the distance
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
        float distance = Vector2.Distance(target.transform.position, transform.position);//find the distance between the ship and the target
        
        Vector2 direction = target.transform.position - transform.position;//find the direction from the ship to the target

        direction = direction.normalized;//normalize the vector

        transform.position += (Vector3)(direction * (distance * ratio));//multiply the distance by the ratio of how far we want to go, and update position 
    }

    public void radars(float range)
    {
        for (int i = 0; i < asteroidTransforms.Count; i++)//test for every asteroid in the list
        {
            if(Vector2.Distance(asteroidTransforms[i].transform.position, transform.position) <= 2.5)//in the asteroid is within range...
            {
                Vector2 direction = asteroidTransforms[i].transform.position - transform.position;//... find the direction to it...
                direction = direction.normalized;

                Debug.DrawLine(transform.position, (transform.position + (Vector3) (direction * maxRange)), Color.green);// ... and draw a line to it
            }
        }
    }
    
    public Vector2 normalize(Vector2 input)//unused
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
