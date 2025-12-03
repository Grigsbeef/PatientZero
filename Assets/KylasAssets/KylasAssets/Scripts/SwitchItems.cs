using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SwitchItems: MonoBehaviour
{
    [Header("Grabbed object")]
    public GameObject objectOne;
    [Header("New object")]
    public GameObject objectTwo;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
    }

    private void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    private void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
    }

    //disables the object and enables the copy for transportation
    private void DisableObj()
    {
        objectOne.SetActive(false);
        objectTwo.SetActive(true);

    }

    //after grabbing the correct object, wait 1/2 second and use the DisableObj method
    private void OnGrab(SelectEnterEventArgs args)
    {
        Invoke("DisableObj", 0.7f);
    }
}
