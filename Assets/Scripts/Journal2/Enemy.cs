using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public GameObject player;

    public Vector2 chargeTarget;
    public Vector2 chargeDirection;
    public Vector2 startingPos;

    public Vector2 screenEdges;

    public Vector3 velocity;
    public Vector3 cancelMomentum;

    public float acceleration = 5f;
    public float deceleration;
    public float distance;

    public bool targetFound = false;

    private void Start()
    {

    }
    private void Update()
    {

        drawCourseLine();

    }

    public void drawCourseLine()
    {
        if (!targetFound)
        {
            Debug.Log("works");
            startingPos = transform.position;
            chargeTarget = player.transform.position;
            distance = Vector2.Distance(startingPos, chargeTarget);

            chargeDirection = (chargeTarget - (Vector2)transform.position).normalized;
            targetFound = true;
        }

        Debug.DrawLine(startingPos, chargeTarget, Color.red);

        //Debug.Log(Vector2.Distance(transform.position, chargeTarget) + " " + distance);
        //screenEdges = findMaxDistance(chargeDirection);

        if (Vector2.Distance(startingPos, transform.position) < distance)
        {
            velocity += acceleration * Time.deltaTime * (Vector3) chargeDirection;
        }
        else
        {
            if (transform.position.x > 17 || transform.position.x < -17 || transform.position.y > 9 || transform.position.y < -9)
            {
                cancelMomentum = velocity.normalized;//normalize the velocity vector...

                if (velocity.magnitude >= 0.1)//... and if the ship is still moving... 
                {
                    velocity -= cancelMomentum * Time.deltaTime * deceleration;//... substact the normalized velocity vector from the velocity vector
                }
                else
                {
                    targetFound = false;
                }
            }   
        }



        transform.position += velocity * Time.deltaTime;
    }

    //public Vector2 findMaxDistance(Vector2 direction)
    //{
    //    float endX;
    //    float endY;
    //    if (direction.x > 0)
    //    {
    //        endX = 18;
    //    }
    //    else
    //    {
    //        endX = -18;
    //    }

    //    if (direction.y > 0)
    //    {
    //        endY = 10;
    //    }
    //    else
    //    {
    //        endY = -10;
    //    }

    //    return new Vector2(endX, endY);
    //}
}
