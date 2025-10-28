using UnityEngine;

public class CameraRigFollowRB : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] Rigidbody targetRb;     // drag your Player's Rigidbody here

    [Header("Framing")]
    [SerializeField] float height = 1.6f;    // camera height above player feet
    [SerializeField] float distance = 3.0f;  // distance behind player
    [SerializeField] float lookHeight = 1.2f;

    [Header("Smoothing")]
    [SerializeField] float followSmooth = 0.12f; // SmoothDamp time (lower = snappier)
    [SerializeField] float yawLerp = 12f;        // how quickly we turn to face player (deg/sec-like)

    [Header("Collision")]
    [SerializeField] LayerMask geometryMask = ~0; // set to your museum geometry layer(s)
    [SerializeField] float sphereRadius = 0.25f;
    [SerializeField] float hitBuffer = 0.12f;

    [Header("Ceiling Clamp")]
    [SerializeField] float headClearance = 0.15f; // keep camera this far below ceiling
    [SerializeField] float maxExtraHeight = 0.8f; // don’t let camera float too high above target

    Vector3 vel; // for SmoothDamp

    void LateUpdate()
    {
        if (!targetRb) return;

        // Use the Rigidbody's (interpolated) position for jitter-free follow
        Vector3 targetPos = targetRb.position;

        // Build a yaw-only forward from target (ignores any physics pitch/roll)
        Vector3 fwd = targetRb.transform.forward;
        fwd = Vector3.ProjectOnPlane(fwd, Vector3.up).normalized;
        if (fwd.sqrMagnitude < 0.0001f) fwd = transform.forward;

        // Desired camera position (behind target, at fixed height)
        Vector3 desired = targetPos - fwd * distance + Vector3.up * height;

        // Clamp max camera height relative to target to avoid seeing over ceilings on slopes
        float maxY = targetPos.y + height + maxExtraHeight;
        if (desired.y > maxY) desired.y = maxY;

        // Collision avoidance (spherecast from head to desired)
        Vector3 head = targetPos + Vector3.up * height;
        Vector3 dir = desired - head;
        float len = dir.magnitude;
        if (len > 0.001f)
        {
            dir /= len;
            if (Physics.SphereCast(head, sphereRadius, dir, out RaycastHit hit, len, geometryMask, QueryTriggerInteraction.Ignore))
            {
                desired = hit.point - dir * hitBuffer;
            }
        }

        // Ceiling clamp: keep camera under any ceiling directly above desired
        if (Physics.Raycast(desired, Vector3.up, out RaycastHit ceilHit, 5f, geometryMask, QueryTriggerInteraction.Ignore))
        {
            float ceilingY = ceilHit.point.y;
            float clampY = ceilingY - headClearance;
            if (desired.y > clampY) desired.y = clampY;
        }

        // Smooth position
        transform.position = Vector3.SmoothDamp(transform.position, desired, ref vel, followSmooth);

        // Smooth yaw to face the player horizontally
        Vector3 toLook = (targetPos + Vector3.up * lookHeight) - transform.position;
        Vector3 flat = Vector3.ProjectOnPlane(toLook, Vector3.up);
        if (flat.sqrMagnitude > 0.0001f)
        {
            Quaternion want = Quaternion.LookRotation(flat.normalized, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, want, 1f - Mathf.Exp(-yawLerp * Time.deltaTime));
        }

        // Keep rig level (no roll)
        Vector3 e = transform.eulerAngles;
        transform.rotation = Quaternion.Euler(0f, e.y, 0f);
    }
}
