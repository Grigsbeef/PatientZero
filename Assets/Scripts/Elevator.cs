using UnityEngine;
using UnityEngine.InputSystem;

public class Elevator : MonoBehaviour
{
    [Header("Elevator Settings")]
    public Transform elevatorPlatform;     // The platform to move
    public Vector3 targetPosition;         // World-space position the elevator will move to
    public float speed = 2f;               // Movement speed

    private bool moveElevator = false;
    private Vector3 startPosition;

    private void Start()
    {
        if (elevatorPlatform != null)
            startPosition = elevatorPlatform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Make sure only the player triggers it
        if (other.CompareTag("Player"))
        {
            moveElevator = true;
        }
    }

    private void Update()
    {
        if (moveElevator && elevatorPlatform != null)
        {
            elevatorPlatform.position = Vector3.MoveTowards(
                elevatorPlatform.position,
                targetPosition,
                speed * Time.deltaTime
            );
        }
    }
}
