using UnityEngine;

public class TestPhysics : MonoBehaviour
{
    public GameObject thing;

    public Rigidbody2D rbGREEN;
    public Rigidbody2D rbORANGE;
    public Collider2D collider;
    void Start()
    {
        //Debug.Log(thing.GetComponent<CollisionDetectionMode2D>());
    }

    
    void Update()
    {
        //rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        //{
        //    Debug.Log("its simulated alright ;)");
        //}


        if (rbGREEN.IsTouching(collider) == true)
        {
            Debug.Log("works GREEN");
        }
        else
        {
            Debug.Log("no GREEN");
        }



        if (rbORANGE.IsTouching(collider) == true)
        {
            Debug.Log("works ORANGE");
        }
        else
        {
            Debug.Log("no ORANGE");
        }
    }
}
