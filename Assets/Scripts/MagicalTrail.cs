using UnityEngine;

public class MagicalTrail : MonoBehaviour
{
    public Transform player;
    public Transform target;
    public float speed = 5f;

    private Vector3 startPoint;
    private Vector3 endPoint;
    private float journeyTime = 0f;

    void Update()
    {
        if (player == null || target == null) return;

        // Move from player to target
        startPoint = player.position;
        endPoint = target.position;

        journeyTime += Time.deltaTime * speed;
        float t = Mathf.PingPong(journeyTime, 1f); // goes there and back
        transform.position = Vector3.Lerp(startPoint, endPoint, t);
    }
}
