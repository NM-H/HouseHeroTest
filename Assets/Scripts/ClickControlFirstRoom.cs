using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickControlFirstRoom : MonoBehaviour
{
    public GameObject MudStain;
    public GameObject DryPlant;
    public GameObject FreshPlant;
    public GameObject WaterCan;  // Water can object (to pick up)
    public GameObject Towel;
    public Text NarrationTextFirstRoom;

    private bool hasWaterCan = false;
    private bool hasTowel = false;

    void Start()
    {
        // Ensure all necessary objects are set active or inactive properly
        if (FreshPlant != null) FreshPlant.SetActive(false);
        if (MudStain != null) MudStain.SetActive(true);
        if (DryPlant != null) DryPlant.SetActive(true);

        if (NarrationTextFirstRoom != null)
            NarrationTextFirstRoom.text = "Ohh, I brought some mud stains from outside. I need to clean this stain first.";
        else
            Debug.LogError("NarrationTextFirstRoom is not assigned in the Inspector!");
    }

    public void PickUpTowel()
    {
        if (Towel != null)
        {
            hasTowel = true;
            Towel.SetActive(false); // Hide the towel object
            UpdateNarration("I picked up the towel. Now I need to clean the stain.");
        }
    }

    public void PickUpWaterCan()
    {
        if (WaterCan != null)
        {
            hasWaterCan = true;
            WaterCan.SetActive(false); // Hide the water can object
            UpdateNarration("I picked up the watering can. Now let's water the plant.");
        }
    }

    public void CleanMud()
    {
        if (!MudStain || !NarrationTextFirstRoom) return;

        if (hasTowel && MudStain.activeSelf)
        {
            MudStain.SetActive(false);
            UpdateNarration("Yay! I cleaned the mud stain with the towel!");
        }
        else if (!hasTowel)
        {
            UpdateNarration("I need a towel to clean the mud.");
        }
    }

    public void WaterPlant()
    {
        if (!DryPlant || !FreshPlant || !NarrationTextFirstRoom) return;

        if (hasWaterCan && DryPlant.activeSelf)
        {
            DryPlant.SetActive(false);
            FreshPlant.SetActive(true);
            UpdateNarration("Yay! I watered the plant, and it looks fresh now!");
        }
        else if (!hasWaterCan)
        {
            UpdateNarration("I need a watering can to water the plant.");
        }
    }
    public void GoToSecondRoom()
    {
        Debug.Log("Going to SecondRoom..."); // Check if function is being called
        SceneManager.LoadScene("SecondRoom"); // Load the next scene
    }

    private void UpdateNarration(string message)
    {
        if (NarrationTextFirstRoom != null)
            NarrationTextFirstRoom.text = message;
    }
}
