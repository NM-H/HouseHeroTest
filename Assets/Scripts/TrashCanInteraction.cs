using UnityEngine;
using UnityEngine.UI;

public class TrashcanInteraction : MonoBehaviour
{
    public Text narrationText; // Reference to the narration text UI
    private bool isInteractive = false; // Start with non-interactive trashcan

    void Start()
    {
        // Make sure trashcan interaction is initially disabled
        gameObject.GetComponent<Button>().interactable = false;  // Disables interaction
    }

    void OnMouseDown()
    {
        // This will only be called when the trashcan is clickable
        if (isInteractive)
        {
            if (narrationText != null)
            {
                narrationText.text = "I opened the trashcan. It's full of old food.";
            }
            // Additional interactions when clicked
        }
    }

    // Method to make the trashcan interactive
    public void EnableInteraction()
    {
        isInteractive = true;
        gameObject.GetComponent<Button>().interactable = true; // Enable interaction
    }
}
