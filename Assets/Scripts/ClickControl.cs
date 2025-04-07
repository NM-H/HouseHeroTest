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
    public GameObject MudStain;
    public GameObject DryPlant;
    public GameObject FreshPlant;
    public GameObject WaterCan;  // Water can object (to pick up)
    public GameObject Towel;

    private bool hasWaterCan = false;
    private bool hasTowel = false;

    void Start()
    {
        // Scene 1 setup
        if (key != null) key.SetActive(false);

        // Scene 2 setup
        if (FreshPlant != null) FreshPlant.SetActive(false);

        // Set initial narration text
        if (narrationText != null)
        {
            narrationText.text = "I just got home. I need to find the key to unlock the door. Dad always tells me to hide the key behind one of the rock tiles, which one did I hide it behind?";
        }
    }

    // ===== Scene 1 Methods =====
    public void OnCorrectStoneClick()
    {
        if (keyRevealed) return;

        if (narrationText != null) narrationText.text = "There�s something under this stone...";
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
        if (Towel != null)
        {
            hasTowel = true;
            Towel.SetActive(false); // Hide the towel object
            narrationText.text = "I picked up the towel. Now I need to clean the stain.";
        }
    }

    public void PickUpWaterCan()
    {
        if (WaterCan != null)
        {
            hasWaterCan = true;
            WaterCan.SetActive(false); // Hide the water can object
            narrationText.text = "I picked up the watering can. Now let's water the plant.";
        }
    }
    public void CleanMud()
    {
        if (!MudStain) return;

        if (hasTowel && MudStain.activeSelf)
        {
            MudStain.SetActive(false);
            narrationText.text = "Yay! I cleaned the mud stain with the towel!";
        }
        else if (!hasTowel)
        {
            narrationText.text = "I need a towel to clean the mud.";
        }
    }
    public void WaterPlant()
    {
        if (!DryPlant) return;

        if (hasWaterCan && DryPlant.activeSelf)
        {
            DryPlant.SetActive(false);
            narrationText.text = "Yay! I watered the plant, and it looks fresh now!";
        }
        else if (!hasWaterCan)
        {
            narrationText.text = "I need a watering can to water the plant.";
        }
    }

    public void GoToSecondRoom()
    {
        Debug.Log("Going to SecondRoom..."); // Check if function is being called
        SceneManager.LoadScene("SecondRoom"); // Load the next scene
    }

}
// public void WaterPlant()
// {
//     if (hasWaterCan && dryPlant != null && dryPlant.activeSelf)
//     {
//         dryPlant.SetActive(false);
//         if (freshPlant != null) freshPlant.SetActive(true);
//         if (narrationTextFirstRoom != null) narrationTextFirstRoom.text = "You watered the plant, and it looks fresh now!";
//     }
//     else if (!hasWaterCan && narrationTextFirstRoom != null)
//     {
//         narrationTextFirstRoom.text = "You need a watering can to water the plant.";
//     }
// }
