using UnityEngine;
using UnityEngine.InputSystem;

public class Elevator : MonoBehaviour
{
    public Transform bottomPoint;     // The position the platform should move to
    public float speed = 2f;          // Movement speed
    private bool moveDown = false;    // Controls movement

    void Update()
    {
        if (moveDown)
        {
            // Move the platform down toward bottomPoint
            transform.position = Vector3.MoveTowards(
                transform.position,
                bottomPoint.position,
                speed * Time.deltaTime
            );
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            moveDown = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            moveDown = false;
        }
    }
}
