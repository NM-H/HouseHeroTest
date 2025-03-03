using UnityEngine;
using UnityEngine.UI;

public class ClickControl : MonoBehaviour
{
    public GameObject key;
    public GameObject door;
    public Text narrationText;
    private bool hasKey = false;

    void Start()
    {
        key.SetActive(false);
        narrationText.text = "I just got home. I need to find the key to unlock the door.";
    }

    public void OnStoneClick()
    {
        narrationText.text = "There’s something under this stone...";
        key.SetActive(true);
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
            UnityEngine.SceneManagement.SceneManager.LoadScene("InsideHouse");
        }
        else
        {
            narrationText.text = "The door is locked. I need to find the key.";
        }
    }
}
