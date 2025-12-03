using UnityEngine;

public class GazeTooltip : MonoBehaviour
{
    public GameObject tooltipPrefab;
    private GameObject tooltipInstance;

    public float activationAngle = 15f; 
    public float maxDistance = 3f;      

    private Transform playerCamera;

    void Start()
    {
        playerCamera = Camera.main.transform;
    }

    void Update()
    {
        Vector3 toObject = (transform.position - playerCamera.position).normalized;
        float angle = Vector3.Angle(playerCamera.forward, toObject);
        float distance = Vector3.Distance(playerCamera.position, transform.position);

        // Show tooltip if looking at object AND close enough
        if (angle < activationAngle && distance < maxDistance)
        {
            if (tooltipInstance == null)
            {
                tooltipInstance = Instantiate(tooltipPrefab, transform.position + Vector3.up * 0.3f, Quaternion.identity);
                tooltipInstance.transform.LookAt(playerCamera);
                tooltipInstance.transform.Rotate(0, 180f, 0); 
            }
        }
        else
        {
            if (tooltipInstance != null)
            {
                Destroy(tooltipInstance);
            }
        }
    }
}
