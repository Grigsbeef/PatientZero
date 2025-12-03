using UnityEngine;
using UnityEngine.UI;

public class TriggerUI : MonoBehaviour
{
    [Header("Assign the UI Canvas")]
    public GameObject canvasUI;

    private void TriggerWhenOn(Collider other)
    {
        // Check if the player entered
        if (other.CompareTag("Player"))
        {
            //activates UI when player is on the trigger
            if (canvasUI != null)
            {
                canvasUI.SetActive(true);
                Invoke("DisableUI", 5f);
            }

        }
    }

    private void DisableUI()
    {
        canvasUI.SetActive(false);
    }

    private void TriggerWhenOff(Collider other)
    {
        //checks if player leaves
        if (other.CompareTag("Player"))
        {
            //set UI to not active when player gets off it
            if (canvasUI != null)
            {
                canvasUI.SetActive(false);
            }
        }
    }
}
