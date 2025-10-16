using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Transform cameraTransform; // drag your Main Camera here (optional)

    Rigidbody rb;
    Vector3 moveInput;

    void Awake()
    {
        // Get the Rigidbody on this GameObject
        rb = GetComponent<Rigidbody>();

        if (rb) { rb.angularVelocity = Vector3.zero; }
        
        // If camera not assigned, grab the MainCamera automatically
        if (!cameraTransform && Camera.main)
            cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // Read player input (WASD / arrow keys)
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Determine move direction (camera-relative if possible)
        if (cameraTransform)
        {
            Vector3 forward = Vector3.ProjectOnPlane(cameraTransform.forward, Vector3.up).normalized;
            Vector3 right = Vector3.ProjectOnPlane(cameraTransform.right, Vector3.up).normalized;
            moveInput = (forward * vertical + right * horizontal).normalized;
        }
        else
        {
            moveInput = new Vector3(horizontal, 0f, vertical).normalized;
        }
    }

    void FixedUpdate()
    {
        if (!rb) return; // safety check

        // Move the player
        Vector3 move = moveInput * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);
    }
}
