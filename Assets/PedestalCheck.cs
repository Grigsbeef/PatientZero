using UnityEngine;

public class PedestalCheck : MonoBehaviour
{
    public string correctTag;
    public bool isCorrect = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(correctTag))
        {
            isCorrect = true;

            // Lock the object in place
            if (other.attachedRigidbody != null)
                other.attachedRigidbody.isKinematic = true;

            other.transform.position = transform.position + Vector3.up * 0.1f;
            other.transform.rotation = transform.rotation;

            Debug.Log("Correct object placed on " + gameObject.name);
        }
    }
}
