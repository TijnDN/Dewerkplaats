using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    public int totalPuzzles = 5;
    private int completedPuzzles = 0;

    void Awake()
    {
        
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    
    public void CompletePuzzle()
    {
        completedPuzzles++;
        Debug.Log("Puzzle completed! Progress: " + completedPuzzles + "/" + totalPuzzles);

        if (completedPuzzles >= totalPuzzles)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        Debug.Log(" You completed all 5 puzzles! You win!");
        
    }
}