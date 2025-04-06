using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickControl : MonoBehaviour
{
    // ========== SCENE 1 (Outside) ==========
    public GameObject key;
    public GameObject stone11;
    public GameObject door;
    public Text narrationText;

    private bool hasKey = false;
    private bool keyRevealed = false;

    // ========== SCENE 2 (First Room) ==========
    public GameObject mudStain;
    public GameObject dryPlant;
    public GameObject freshPlant;
    public GameObject waterCan;
    public GameObject towel;
    public Text narrationTextFirstRoom;

    private bool hasWaterCan = false;
    private bool hasTowel = false;

    void Start()
    {
        // Scene 1 setup
        if (key != null) key.SetActive(false);

        // Scene 2 setup
        if (freshPlant != null) freshPlant.SetActive(false);

        // Set initial narration text
        if (narrationText != null)
        {
            narrationText.text = "I just got home. I need to find the key to unlock the door.";
        }
    }

    // ===== Scene 1 Methods =====
    public void OnCorrectStoneClick()
    {
        if (keyRevealed) return;

        if (narrationText != null) narrationText.text = "There’s something under this stone...";
        if (key != null) key.SetActive(true);
        keyRevealed = true;
    }

    public void OnWrongStoneClick()
    {
        if (narrationText != null) narrationText.text = "Just a regular stone. I should try another one.";
    }

    public void OnKeyClick()
    {
        if (narrationText != null) narrationText.text = "I found the key! Now I can unlock the door.";
        hasKey = true;
        if (key != null) key.SetActive(false);
    }

    public void OnDoorClick()
    {
        if (hasKey)
        {
            if (narrationText != null) narrationText.text = "I unlocked the door. Time to head inside.";
            SceneManager.LoadScene("FirstRoom");
        }
        else
        {
            if (narrationText != null) narrationText.text = "The door is locked. I need to find the key.";
        }
    }

    // ===== Scene 2 Methods =====
    public void PickUpTowel()
    {
        hasTowel = true;
        if (narrationTextFirstRoom != null) narrationTextFirstRoom.text = "You picked up the towel.";
        if (towel != null) towel.SetActive(false);
    }

    public void PickUpWaterCan()
    {
        hasWaterCan = true;
        if (narrationTextFirstRoom != null) narrationTextFirstRoom.text = "You picked up the watering can.";
        if (waterCan != null) waterCan.SetActive(false);
    }

    public void CleanMud()
    {
        if (hasTowel && mudStain != null && mudStain.activeSelf)
        {
            mudStain.SetActive(false);
            if (narrationTextFirstRoom != null) narrationTextFirstRoom.text = "You cleaned the mud stain with the towel!";
        }
        else if (!hasTowel && narrationTextFirstRoom != null)
        {
            narrationTextFirstRoom.text = "You need a towel to clean the mud.";
        }
    }

    public void WaterPlant()
    {
        if (hasWaterCan && dryPlant != null && dryPlant.activeSelf)
        {
            dryPlant.SetActive(false);
            if (freshPlant != null) freshPlant.SetActive(true);
            if (narrationTextFirstRoom != null) narrationTextFirstRoom.text = "You watered the plant, and it looks fresh now!";
        }
        else if (!hasWaterCan && narrationTextFirstRoom != null)
        {
            narrationTextFirstRoom.text = "You need a watering can to water the plant.";
        }
    }
}