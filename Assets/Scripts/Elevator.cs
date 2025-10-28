using UnityEngine;
using UnityEngine.InputSystem;

public class Elevator : MonoBehaviour
{
    public Transform platform;          // The platform to move
    public float moveDistance = 2f;     // How far down it should move
    public float moveSpeed = 1f;        // Speed of movement
    public InputActionProperty gripAction; // Grip or any assigned input

    private bool isMoving = false;
    private Vector3 targetPosition;

    private void OnEnable()
    {
        gripAction.action.performed += OnGripPressed;
    }

    private void OnDisable()
    {
        gripAction.action.performed -= OnGripPressed;
    }

    private void OnGripPressed(InputAction.CallbackContext context)
    {
        if (isMoving) return;

        // Set new target below current position
        targetPosition = platform.position + Vector3.down * moveDistance;
        StartCoroutine(MovePlatform());
    }

    private System.Collections.IEnumerator MovePlatform()
    {
        isMoving = true;

        while (Vector3.Distance(platform.position, targetPosition) > 0.01f)
        {
            platform.position = Vector3.MoveTowards(platform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        platform.position = targetPosition; // Snap to target
        isMoving = false;
    }
}
