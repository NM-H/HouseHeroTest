using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    public GameObject puzzleCanvas;
    public GameObject feedbackText;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void CheckSolution()
    {
        PuzzleSlot[] slots = FindObjectsOfType<PuzzleSlot>();
        foreach (PuzzleSlot slot in slots)
        {
            if (slot.transform.childCount == 0) return;

            string droppedName = slot.transform.GetChild(0).name;
            if (!droppedName.Contains(slot.correctPieceName))
            {
                Debug.Log("Wrong arrangement!");
                return;
            }
        }

        GameState.HomeworkDone = true;
        DialogueManager.Instance.StartDialogue(new System.Collections.Generic.List<string>
        {
            "Congrats! You are now a House Hero good job."
        });
        Invoke(nameof(EndPuzzle), 3f);
    }

    void EndPuzzle()
    {
        SceneManager.LoadScene("EndScreen");
    }
}
