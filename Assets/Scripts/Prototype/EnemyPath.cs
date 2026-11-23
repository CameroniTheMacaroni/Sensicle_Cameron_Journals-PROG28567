using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    public List<Vector2> waypoints;

    public int targetPosition;
    public Vector2 direction;
    public float speed = 5f;
    public Vector2 roughPosition;

    void Start()
    {
        waypoints.Add(new Vector2(-3, 20));
        waypoints.Add(new Vector2(6, 20));
        waypoints.Add(new Vector2(6, 9));
        waypoints.Add(new Vector2(20, 9));
        waypoints.Add(new Vector2(20, 1));
        //5
        waypoints.Add(new Vector2(13, 1));
        waypoints.Add(new Vector2(13, -17));
        waypoints.Add(new Vector2(4, -17));
        waypoints.Add(new Vector2(4, -13));
        waypoints.Add(new Vector2(-10, -13));
        //10
        waypoints.Add(new Vector2(-10, -3));
        waypoints.Add(new Vector2(-6, -3));
        waypoints.Add(new Vector2(-6, 3));
        waypoints.Add(new Vector2(-26, 3));
        waypoints.Add(new Vector2(-26, 11));
        //15
        waypoints.Add(new Vector2(-20, 11));
        waypoints.Add(new Vector2(-20, 17));
        waypoints.Add(new Vector2(-24, 17));
        waypoints.Add(new Vector2(-24, 23));
        waypoints.Add(new Vector2(-13, 23));
        //20
        waypoints.Add(new Vector2(-13, 15));
        waypoints.Add(new Vector2(-3, 15));
    }

    // Update is called once per frame
    void Update()
    {
        direction = (waypoints[targetPosition] - (Vector2) transform.position).normalized;
        transform.position += (Vector3) direction * Time.deltaTime * speed;

        roughPosition = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));
        if (roughPosition == waypoints[targetPosition])
        {
            if (targetPosition < waypoints.Count - 1)
            {
                targetPosition++;
            }
            else
            {
                targetPosition = 0;
            }
        }
    }
}
