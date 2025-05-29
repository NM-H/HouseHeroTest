using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ClickControl : MonoBehaviour
{
    // SCENE 1
    public GameObject key;
    public GameObject stone11;
    public GameObject door;
    public GameObject Trashcan;

    private bool hasKey = false;
    private bool keyRevealed = false;

    // SCENE 2
    public GameObject MudStain;
    public GameObject DryPlant;
    public GameObject FreshPlant;
    public GameObject WaterCan;
    public GameObject Towel;

    private bool hasWaterCan = false;
    private bool hasTowel = false;

    // SCENE 3
    public GameObject Fridge;
    public GameObject Sandwich;
    public GameObject Scene3Trashcan;
    public GameObject Table;
    public GameObject Homework;
    public GameObject FridgeSmell;

    private bool hasSandwich = false;
    private bool homeworkDone = false;

    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "OutHouse")
        {
            if (key != null) key.SetActive(false);
            if (Trashcan != null) Trashcan.SetActive(GameState.TrashTakenOut);

            StartSceneDialogue(new List<string>
            {
                "I just got home. I need to find the key to unlock the door.",
                "Dad always tells me to hide the key behind one of the rock tiles... which one did I hide it behind?"
            });
        }
        else if (currentScene == "FirstRoom")
        {
            if (FreshPlant != null) FreshPlant.SetActive(false);

            StartSceneDialogue(new List<string>
            {
                "Home Sweet Home...",
                "Oops, it looks like I brought mud inside the house.",
                "I need to clean this up with a towel.",
                "I also need to water the plant."
            });
        }
        else if (currentScene == "SecondRoom")
        {
            if (Sandwich != null) Sandwich.SetActive(false);
            if (FridgeSmell != null) FridgeSmell.SetActive(!GameState.TrashTakenOut);

            StartSceneDialogue(new List<string>
            {
                "Yay, the kitchen...",
                "Ew, what's that smell?",
                "I think it's coming from the fridge. Let me check it out.",
                "Oh, I need to throw this out and take out the trash."
            });
        }
    }

    void StartSceneDialogue(List<string> lines)
    {
        DialogueManager.Instance.StartDialogue(lines);
    }

    // Scene 1
    public void OnCorrectStoneClick()
    {
        if (keyRevealed) return;

        StartSceneDialogue(new List<string> { "There's something under this stone..." });
        if (key != null) key.SetActive(true);
        keyRevealed = true;
    }

    public void OnWrongStoneClick()
    {
        StartSceneDialogue(new List<string> { "Just a regular stone. I should try another one." });
    }

    public void OnKeyClick()
    {
        StartSceneDialogue(new List<string> { "I found the key! Now I can unlock the door." });
        hasKey = true;
        if (key != null) key.SetActive(false);
    }

    public void OnDoorClick()
    {
        if (hasKey)
        {
            StartSceneDialogue(new List<string> { "I unlocked the door. Time to head inside." });
            SceneManager.LoadScene("FirstRoom");
        }
        else
        {
            StartSceneDialogue(new List<string> { "The door is locked. I need to find the key." });
        }
    }

    // Scene 2
    public void PickUpTowel()
    {
        if (Towel != null)
        {
            hasTowel = true;
            Towel.SetActive(false);
            StartSceneDialogue(new List<string> { "I picked up the towel. Now I can clean the mud stains." });
        }
    }

    public void PickUpWaterCan()
    {
        if (WaterCan != null)
        {
            hasWaterCan = true;
            WaterCan.SetActive(false);
            StartSceneDialogue(new List<string> { "I picked up the watering can. Now I can water the plant." });
        }
    }

    public void CleanMud()
    {
        if (!MudStain) return;

        if (hasTowel && MudStain.activeSelf)
        {
            MudStain.SetActive(false);
            StartSceneDialogue(new List<string> { "Yay! I cleaned the mud stain with the towel!" });
        }
        else if (!hasTowel)
        {
            StartSceneDialogue(new List<string> { "I need a towel to clean the mud." });
        }
    }

    public void WaterPlant()
    {
        if (!DryPlant) return;

        if (hasWaterCan && DryPlant.activeSelf)
        {
            DryPlant.SetActive(false);
            if (FreshPlant != null) FreshPlant.SetActive(true);
            StartSceneDialogue(new List<string>
            {
                "Yay! I watered the plant, and it looks fresh now.",
                "I'm feeling hungry... Let's go get a sandwich from the kitchen, then start my homework."
            });
        }
        else if (!hasWaterCan)
        {
            StartSceneDialogue(new List<string> { "I need a watering can to water the plant." });
        }
    }

    public void GoToSecondRoom()
    {
        SceneManager.LoadScene("SecondRoom");
    }

    // Scene 3
    public void OnFridgeClick()
    {
        if (Sandwich != null) Sandwich.SetActive(true);
        StartSceneDialogue(new List<string> { "There’s some smelly food in here… I should throw it out." });
    }

    public void OnSandwichClick()
    {
        hasSandwich = true;
        if (Sandwich != null) Sandwich.SetActive(false);
        StartSceneDialogue(new List<string> { "Gross! I’ll toss this in the trash." });
    }

    public void OnScene3TrashcanClick()
    {
        if (hasSandwich)
        {
            GameState.TrashTakenOut = true;
            if (FridgeSmell != null) FridgeSmell.SetActive(false);
            StartSceneDialogue(new List<string> { "I threw the sandwich out. That smell was awful!" });
        }
        else
        {
            StartSceneDialogue(new List<string> { "I should find what’s causing that smell first." });
        }
    }

    public void OnTableClick()
    {
        if (!homeworkDone)
        {
            homeworkDone = true;
            GameState.HomeworkDone = true;
            StartSceneDialogue(new List<string> { "Homework time… alright, all done!" });
        }
        else
        {
            StartSceneDialogue(new List<string> { "I already finished my homework." });
        }
    }
}
