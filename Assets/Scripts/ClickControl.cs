using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ClickControl : MonoBehaviour
{
    // ========== SCENE 1 (OutHouse)
    public GameObject key;
    public GameObject stone11;
    public GameObject door;
    public Text narrationText;

    private bool hasKey = false;
    private bool keyRevealed = false;

    // ========== SCENE 2 (First Room)
    public GameObject MudStain;
    public GameObject DryPlant;
    public GameObject FreshPlant;
    public GameObject WaterCan;
    public GameObject Towel;

    private bool hasWaterCan = false;
    private bool hasTowel = false;

    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "OutHouse")
        {
            if (key != null) key.SetActive(false);

            // Start the coroutine for the OutHouse scene dialogue
            StartCoroutine(OutHouseSceneIntroDialogue());
        }
        else if (currentScene == "FirstRoom")
        {
            if (FreshPlant != null) FreshPlant.SetActive(false);

            StartCoroutine(FirstRoomIntroDialogue());
        }
        else if (currentScene == "SecondRoom")
        {
            StartCoroutine(SecondRoomIntroDialogue());
        }
    }

    // ===== Dialogue Coroutines =====

    IEnumerator OutHouseSceneIntroDialogue()
    {
        narrationText.text = "I just got home. I need to find the key to unlock the door.";
        yield return new WaitForSeconds(3.5f);
        narrationText.text = "Dad always tells me to hide the key behind one of the rock tiles, which one did I hide it behind?";
        yield return new WaitForSeconds(3.5f);
    }

    IEnumerator FirstRoomIntroDialogue()
    {
        narrationText.text = "Home Sweet Home...";
        yield return new WaitForSeconds(3.5f);
        narrationText.text = "Oops, it looks like I brought mud inside the house.";
        yield return new WaitForSeconds(3.5f);
        narrationText.text = "I need to use the towel to clean this up and water my plant.";
        yield return new WaitForSeconds(3.5f);
    }

    IEnumerator SecondRoomIntroDialogue()
    {
        narrationText.text = "I'm hungry, I should make myself a sandwich...";
        yield return new WaitForSeconds(3.5f);
        narrationText.text = "Ew, what's that smell?";
        yield return new WaitForSeconds(3.5f);
        narrationText.text = "I think it's coming from the fridge. Let me check it out.";
        yield return new WaitForSeconds(3.5f);
        narrationText.text = "Oh, I need to throw this out and take out the trash.";
        yield return new WaitForSeconds(3.5f);
    }

    // Scene 1 Methods
    public void OnCorrectStoneClick()
    {
        if (keyRevealed) return;

        if (narrationText != null) narrationText.text = "There's something under this stone...";
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

    // Scene 2 Methods
    public void PickUpTowel()
    {
        if (Towel != null)
        {
            hasTowel = true;
            Towel.SetActive(false);
            narrationText.text = "I picked up the towel. Now I need to clean the mud stains.";
        }
    }

    public void PickUpWaterCan()
    {
        if (WaterCan != null)
        {
            hasWaterCan = true;
            WaterCan.SetActive(false);
            narrationText.text = "I picked up the watering can. Now let's water the plant.";
        }
    }

    public void CleanMud()
    {
        if (!MudStain) return;

        if (hasTowel && MudStain.activeSelf)
        {
            MudStain.SetActive(false);
            narrationText.text = "Yay! I cleaned the mud stains with the towel!";
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
            narrationText.text = "Yay! I watered the plant, and it looks fresh now! Let's go to the kitchen";
        }
        else if (!hasWaterCan)
        {
            narrationText.text = "I need a watering can to water the plant.";
        }
    }

    public void GoToSecondRoom()
    {
        Debug.Log("Going to SecondRoom...");
        SceneManager.LoadScene("SecondRoom");
    }
}
