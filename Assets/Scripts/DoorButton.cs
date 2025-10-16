using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class DoorButton : MonoBehaviour
{
    public XRBaseInteractable button; // Assign your XR button here
    public Animator doorAnimator;     // Assign the door’s Animator

    private bool isOpen = false;

    private void OnEnable()
    {
        button.selectEntered.AddListener(OnButtonPressed);
    }

    private void OnDisable()
    {
        button.selectEntered.RemoveListener(OnButtonPressed);
    }

    private void OnButtonPressed(SelectEnterEventArgs args)
    {
        if (isOpen)
        {
            doorAnimator.SetTrigger("Close");
            isOpen = false;
        }
        else
        {
            doorAnimator.SetTrigger("Open");
            isOpen = true;
        }
    }
}
