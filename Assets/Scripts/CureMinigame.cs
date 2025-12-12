using UnityEngine;

public class CureMinigame : MonoBehaviour
{
    private int TotalCureItems = 5;
    private int CurCureItems = 0;
    private bool flag = false;

    public GameObject StartingPuzzleText;
    public GameObject EndingPuzzleText;
    public GameObject Cure;
    // Update is called once per frame
    void Update()
    {
        if(CurCureItems == TotalCureItems && !flag)
        {
            StartingPuzzleText.SetActive(false);
            EndingPuzzleText.SetActive(true);
            Cure.SetActive(true);
            flag = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("itemCure"))
        {
            CurCureItems++;
            other.gameObject.SetActive(false);
        }
    }
}
