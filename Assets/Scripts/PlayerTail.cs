using UnityEngine;

public class PlayerTail : MonoBehaviour
{
    public Transform target; // Next object to reach
    private LineRenderer line;

    void Start()
    {
        line = gameObject.AddComponent<LineRenderer>();
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        line.material = new Material(Shader.Find("Unlit/Color"));
        line.material.color = Color.cyan;
        line.positionCount = 2;
    }

    void Update()
    {
        if (target != null)
        {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, target.position);
        }
    }
}
