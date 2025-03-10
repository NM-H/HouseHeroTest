using UnityEngine;
using UnityEngine.UI;

public class ClickControl : MonoBehaviour
{
    public GameObject key;
    public GameObject thirdStone;  // The stone hiding the key
    public Text narrationText;
    private bool hasKey = false;
    private bool keyRevealed = false; // Ensure the key is only revealed once

    void Start()
    {
        key.SetActive(false); // Hide the key at the start
        narrationText.text = "I just got home. I need to find the key to unlock the door.";
    }

    public void OnStoneClick(GameObject clickedStone)
    {
        if (keyRevealed) return; // Stop interaction if the key is already revealed

        if (clickedStone == thirdStone)  // Check if the clicked stone is "ThirdStone"
        {
            narrationText.text = "There’s something under this stone...";
            key.SetActive(true);  // Reveal the key
            keyRevealed = true;  // Prevent multiple reveals
        }
        else
        {
            narrationText.text = "Just a regular stone. I should try another one.";
        }
    }

    public void OnKeyClick()
    {
        narrationText.text = "I found the key! Now I can unlock the door.";
        hasKey = true;
        key.SetActive(false);
    }

    public void OnDoorClick()
    {
        if (hasKey)
        {
            narrationText.text = "I unlocked the door. Time to head inside.";
            UnityEngine.SceneManagement.SceneManager.LoadScene("FirstRoom"); // Move to next scene
        }
        else
        {
            narrationText.text = "The door is locked. I need to find the key.";
        }
    }
}
