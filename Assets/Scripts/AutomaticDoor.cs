using System.Runtime.InteropServices;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject leftStartPoint;
    public GameObject leftEndPoint;
    public GameObject rightStartPoint;
    public GameObject rightEndPoint;

    public GameObject leftDoor;
    public GameObject rightDoor;
    public float speed = 3.0f;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            leftDoor.transform.position = Vector3.MoveTowards(transform.position, leftEndPoint.transform.position, speed);
            rightDoor.transform.position = Vector3.MoveTowards(transform.position, rightEndPoint.transform.position, speed);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            leftDoor.transform.position = Vector3.Lerp(transform.position, leftStartPoint.transform.position, speed);
            rightDoor.transform.position = Vector3.Lerp(transform.position, rightStartPoint.transform.position, speed);

        }
    }
}
