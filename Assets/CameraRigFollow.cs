using UnityEngine;

public class CameraRigFollow : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] Transform target;            // drag your Player here

    [Header("Follow")]
    [SerializeField] Vector3 worldOffset = new Vector3(0f, 1.6f, -3f);
    [SerializeField] float followSpeed = 12f;     // position smoothing (higher = snappier)

    [Header("Aim")]
    [SerializeField] float rotateSpeedDeg = 360f; // max degrees/sec to turn toward the player
    [SerializeField] float lookHeight = 1.2f;     // look a bit above the feet
    [SerializeField] bool lockRoll = true;        // keep Z roll at 0

    void LateUpdate()
    {
        if (!target) return;

        // --- Position: follow target smoothly (no rotation inheritance) ---
        Vector3 desired = target.position + worldOffset;
        transform.position = Vector3.Lerp(
            transform.position,
            desired,
            1f - Mathf.Exp(-followSpeed * Time.deltaTime)
        );

        // --- Rotation: look at target horizontally, independent of target's rotation ---
        Vector3 toLook = (target.position + Vector3.up * lookHeight) - transform.position;

        // ignore vertical component for yaw to avoid pitching warble
        Vector3 flat = new Vector3(toLook.x, 0f, toLook.z);
        if (flat.sqrMagnitude > 0.0001f)
        {
            Quaternion targetYaw = Quaternion.LookRotation(flat.normalized, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetYaw,
                rotateSpeedDeg * Time.deltaTime
            );
        }

        // Optional slight downward tilt (set your camera child’s local X rotation instead if you prefer)
        // Example: keep rig level; put tilt on the Camera child.

        if (lockRoll)
        {
            Vector3 e = transform.eulerAngles;
            transform.rotation = Quaternion.Euler(e.x, e.y, 0f); // zero Z roll every frame
        }
    }
}
