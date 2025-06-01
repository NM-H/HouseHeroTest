using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void CheckPuzzleCompletion()
    {
        bool allCorrect = true;

        foreach (PuzzleSlot slot in FindObjectsOfType<PuzzleSlot>())
        {
            if (slot.transform.childCount == 0)
            {
                allCorrect = false;
                break;
            }

            string pieceName = slot.transform.GetChild(0).name;
            if (pieceName != slot.correctPieceName)
            {
                allCorrect = false;
                break;
            }
        }

        if (allCorrect)
        {
            Debug.Log("Puzzle Solved!");
            GameState.HomeworkDone = true;

            // End game or show success
            SceneManager.LoadScene("EndScreen");
        }
    }
}
