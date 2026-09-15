using UnityEngine;

public class SquareScript : MonoBehaviour
{
    public Vector3 squareSizeX;
    public Vector3 squareSizeY;

    public GameObject squarespawner;
    void Start()
    {
        squarespawner = GameObject.Find("SquareSpawner");

        squareSizeX = squarespawner.GetComponent<SquareSpawner>().squareSizeX;
        squareSizeY = squarespawner.GetComponent<SquareSpawner>().squareSizeY;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawLine(transform.position + squareSizeX, transform.position + squareSizeY, Color.red);//top Left
        Debug.DrawLine(transform.position - squareSizeX, transform.position + squareSizeY, Color.red);//top Right
        Debug.DrawLine(transform.position + squareSizeX, transform.position - squareSizeY, Color.red);//bottom Left
        Debug.DrawLine(transform.position - squareSizeX, transform.position - squareSizeY, Color.red);//bottom Right
    }
}
