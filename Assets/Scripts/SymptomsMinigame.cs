using UnityEngine;

public class SymptomsMinigame : MonoBehaviour
{
    private int infected = 0;
    private int maxinfected = 4;
    private bool quarntine = false;
    public void Update()
    {
        if (infected == maxinfected && !quarntine) 
        {
            Debug.Log("All patients have been quarntined");
            quarntine = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Infected")
        {
            infected++;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Infected")
        {
            infected--;
        }
    }
}
