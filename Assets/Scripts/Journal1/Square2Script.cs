using UnityEngine;

public class Square2Script : MonoBehaviour
{
    public Vector3 squareSizeX = new Vector3(0.2f, 0, 0);
    public Vector3 squareSizeY = new Vector3(0, 0.2f, 0);
    void Start()
    {
        
    }

    void Update()
    {
        Debug.DrawLine(transform.position + squareSizeX, transform.position + squareSizeY, Color.red);//top Left
        Debug.DrawLine(transform.position - squareSizeX, transform.position + squareSizeY, Color.red);//top Right
        Debug.DrawLine(transform.position + squareSizeX, transform.position - squareSizeY, Color.red);//bottom Left
        Debug.DrawLine(transform.position - squareSizeX, transform.position - squareSizeY, Color.red);//bottom Right
    }
}
