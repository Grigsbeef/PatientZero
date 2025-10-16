using UnityEngine;
[System.Serializable]

public class bodySocket
{
    public GameObject gameObject;
    [Range(0f, 1f)] public float heightRatio;
}


public class BodyInventory : MonoBehaviour
{
    public GameObject HMD;
    public bodySocket[] bodySockets;

    private Vector3 HMDPosition;
    private Quaternion HMDRotation;
    void Update()
    {
        HMDPosition = HMD.transform.position;
        HMDRotation = HMD.transform.rotation;
        foreach(var bodySocket in bodySockets)
        {
            UpdateBodySocketHeight(bodySocket);
        }
        UpdateSocketInventory();
    }

    private void UpdateBodySocketHeight(bodySocket bodySocket)
    {
        bodySocket.gameObject.transform.position = new Vector3(bodySocket.gameObject.transform.position.x, HMDPosition.y * bodySocket.heightRatio, bodySocket.gameObject.transform.position.z);
    }

    private void UpdateSocketInventory()
    {
        transform.position = new Vector3(HMDPosition.x, 0, HMDPosition.z);
        transform.rotation = new Quaternion(transform.rotation.x, HMDRotation.y, transform.rotation.z, HMDRotation.w);
    }
}
