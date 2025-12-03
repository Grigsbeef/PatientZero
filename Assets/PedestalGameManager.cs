using UnityEngine;

public class PedestalGameManager : MonoBehaviour
{
    public PedestalCheck pedestalA;
    public PedestalCheck pedestalB;
    public PedestalCheck pedestalC;

    public GameObject rewardItem;

    private bool puzzleCompleted = false;

    void Update()
    {
        if (!puzzleCompleted &&
            pedestalA.isCorrect && 
            pedestalB.isCorrect && 
            pedestalC.isCorrect)
        {
            puzzleCompleted = true;
            CompletePuzzle();
        }
    }

    void CompletePuzzle()
    {
        if (rewardItem != null)
            rewardItem.SetActive(true);

        Debug.Log("Puzzle Completed! Reward spawned.");
    }
}
