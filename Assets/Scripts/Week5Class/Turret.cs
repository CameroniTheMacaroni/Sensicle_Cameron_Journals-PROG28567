using System.Drawing;
using Unity.Mathematics;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float angularSpeed = 1;
    public float offset = 90;

    public GameObject target;
    void Start()
    {
        
    }

   
    void Update()
    {
        //Vector2 point = new Vector2(math.cos((transform.eulerAngles.z + offset) * Mathf.Deg2Rad), math.sin((transform.eulerAngles.z + offset) * Mathf.Deg2Rad));//calculate the x and y of the point

        //Debug.DrawLine(transform.position, transform.position + (Vector3) point, UnityEngine.Color.yellow);

        transform.eulerAngles += new Vector3(0, 0, 1) * Time.deltaTime * angularSpeed;

        Vector3 direction2Target = (transform.position - target.transform.position).normalized;
        float dot = Vector3.Dot(transform.up, direction2Target);

        if (dot >= 0)
        {
            Debug.DrawLine(transform.position, transform.position + transform.up, UnityEngine.Color.yellow);
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.up, UnityEngine.Color.magenta);
        }

        float upAngle = Mathf.Atan2(transform.up.y, transform.up.x) * Mathf.Rad2Deg;
        float directionAngle = Mathf.Atan2(direction2Target.y, direction2Target.x) * Mathf.Rad2Deg;

        float deltaAngle = Mathf.DeltaAngle(upAngle, directionAngle);

        Debug.Log(deltaAngle);

        if (dot < 0.95f)
        {
            switch (Mathf.Sign(deltaAngle))
            {
                case 1:
                    transform.Rotate(0, 0, angularSpeed * Time.deltaTime);
                    break;
                case -1:
                    transform.Rotate(0, 0, -angularSpeed * Time.deltaTime);
                    break;
            }
        }
    }
}
