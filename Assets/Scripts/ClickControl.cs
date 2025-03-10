using UnityEngine;
using UnityEngine.UI;

public class ClickControl : MonoBehaviour
{
    public GameObject key;
    public GameObject stone11;
    public Text narrationText;
    private bool hasKey = false;
    private bool keyRevealed = false;

    void Start()
    {
        key.SetActive(false);
        narrationText.text = "I just got home. I need to find the key to unlock the door.";
    }

    public void OnCorrectStoneClick()
    {
        if (keyRevealed) return;

        narrationText.text = "There’s something under this stone...";
        key.SetActive(true);
        keyRevealed = true;
    }

    public void OnWrongStoneClick()
    {
        narrationText.text = "Just a regular stone. I should try another one.";
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
            UnityEngine.SceneManagement.SceneManager.LoadScene("FirstRoom");
        }
        else
        {
            narrationText.text = "The door is locked. I need to find the key.";
        }
    }
}