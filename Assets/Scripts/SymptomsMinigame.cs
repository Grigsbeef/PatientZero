using UnityEngine;

public class SymptomsMinigame : MonoBehaviour
{
    private int infected = 0;
    private int maxinfected = 4;

    public GameObject UItext;
    public void Update()
    {
        if (infected == maxinfected) 
        {
            Debug.Log("All patients have been quarntined");
            UItext.SetActive(true);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Infected")
        {
            infected++;
            other.gameObject.SetActive(false);
        }
    }

    
}
