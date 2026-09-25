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
    public float stopNowDeceleration;
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
            startingPos = transform.position;//track the starting position of the enemy ship
            chargeTarget = player.transform.position;//track the player's position so that we can charge towards it
            distance = Vector2.Distance(startingPos, chargeTarget);//and calculate the distance between the two

            chargeDirection = (chargeTarget - (Vector2)transform.position).normalized;//calculate the direction the ship needs to go
            targetFound = true;//make sure this code only runs when it needs to
        }

        Debug.DrawLine(startingPos, chargeTarget, Color.red);//draw the line of the tragectory

        if (Vector2.Distance(startingPos, transform.position) < distance)//if the enemy ship has not reached its target... 
        {
            velocity += acceleration * Time.deltaTime * (Vector3) chargeDirection;//... accelerate towards the player
        }
        else//if the enemy ship  has reached its target... 
        {
            cancelMomentum = velocity.normalized;//... find the direction the ship is moving in... 
            velocity -= cancelMomentum * Time.deltaTime * deceleration;// ... and slowly substract it from the ships speed

            if (transform.position.x > 17 || transform.position.x < -17 || transform.position.y > 9 || transform.position.y < -9)// if the ship gets too close to the edges
            {
                velocity -= cancelMomentum * Time.deltaTime * stopNowDeceleration;//decelerate a lot so that it slows down in time
            }

            if (velocity.magnitude <= 0.1)//once the ship is stopped...
            {
                targetFound = false;//... find a new target
            }
        }

        transform.position += velocity * Time.deltaTime;// update position
    }
}
