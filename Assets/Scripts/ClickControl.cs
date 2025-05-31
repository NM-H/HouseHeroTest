using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ClickControl : MonoBehaviour
{
    // Scene 1 Objects
    public GameObject key;
    public GameObject stone11;
    public GameObject door;
    public GameObject OutHouseTrashcan;

    private bool hasKey = false;
    private bool keyRevealed = false;

    // Scene 2 Objects
    public GameObject MudStain;
    public GameObject DryPlant;
    public GameObject FreshPlant;
    public GameObject WaterCan;
    public GameObject Towel;

    private bool hasWaterCan = false;
    private bool hasTowel = false;

    // Scene 3 Objects
    public GameObject Fridge;
    public GameObject OpenFridge;
    public GameObject Cheese;
    public GameObject FridgeSmell;
    public GameObject KitchenTrashCan;
    public GameObject TrashBag;
    public GameObject Table;
    public GameObject Homework;
    public GameObject Panel;

    private bool hasCheese = false;
    private bool cheeseThrownOut = false;
    private bool homeworkDone = false;

    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "OutHouse")
        {
            if (key != null) key.SetActive(false);
            if (OutHouseTrashcan != null) OutHouseTrashcan.SetActive(GameState.TrashBagPickedUp);

            if (GameState.TrashBagPickedUp)
            {
                StartSceneDialogue(new List<string>
                {
                    "Throw the trashbag into the trashcan and go back to the kitchen to do your homework."
                });
            }
            else
            {
                StartSceneDialogue(new List<string>
                {
                    "I just got home. I need to find the key to unlock the door.",
                    "Dad always tells me to hide the key behind one of the rock tiles... which one did I hide it behind?"
                });
            }
        }
        else if (currentScene == "FirstRoom")
        {
            if (FreshPlant != null) FreshPlant.SetActive(false);

            if (!GameState.HasEnteredHouse)
            {
                StartSceneDialogue(new List<string>
                {
                    "Home Sweet Home...",
                    "Oops, it looks like I brought mud inside the house.",
                    "I need to clean this up with a towel.",
                    "I also need to water the plant."
                });

                GameState.HasEnteredHouse = true;
            }
        }
        else if (currentScene == "SecondRoom")
        {
            if (Fridge != null) Fridge.SetActive(!GameState.TrashTakenOut);
            if (OpenFridge != null) OpenFridge.SetActive(false);
            if (Cheese != null) Cheese.SetActive(false);
            if (FridgeSmell != null) FridgeSmell.SetActive(!GameState.TrashTakenOut);
            if (Panel != null) Panel.SetActive(true);

            if (GameState.TrashTakenOut && !GameState.HomeworkDone)
            {
                if (Homework != null) Homework.SetActive(true);
                StartSceneDialogue(new List<string> { "It's time to start my homework." });
            }
            else
            {
                if (Homework != null) Homework.SetActive(false);
                StartSceneDialogue(new List<string>
                {
                    "Yay, the kitchen...",
                    "Ew, what's that smell?",
                    "I think it's coming from the fridge. Let me check it out."
                });
            }

            if (TrashBag != null) TrashBag.SetActive(GameState.ShowTrashBag);
        }
    }

    void StartSceneDialogue(List<string> lines)
    {
        DialogueManager.Instance?.StartDialogue(lines);
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
        hasKey = true;
        if (key != null) key.SetActive(false);
        StartSceneDialogue(new List<string> { "I found the key! Now I can unlock the door." });
    }

    public void OnDoorClick()
    {
        if (hasKey || GameState.HasEnteredHouse)
        {
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
        hasTowel = true;
        if (Towel != null) Towel.SetActive(false);
        StartSceneDialogue(new List<string> { "I picked up the towel. Now I can clean the mud stains." });
    }

    public void PickUpWaterCan()
    {
        hasWaterCan = true;
        if (WaterCan != null) WaterCan.SetActive(false);
        StartSceneDialogue(new List<string> { "I picked up the watering can. Now I can water the plant." });
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
        if (Fridge != null) Fridge.SetActive(false);
        if (FridgeSmell != null) FridgeSmell.SetActive(false);
        if (OpenFridge != null) OpenFridge.SetActive(true);
        if (Cheese != null) Cheese.SetActive(true);

        StartSceneDialogue(new List<string> { "The fridge is open. There's a smelly cheese inside." });
    }

    public void OnCheeseClick()
    {
        hasCheese = true;

        if (Cheese != null) Cheese.SetActive(false);
        if (OpenFridge != null) OpenFridge.SetActive(false);
        if (Fridge != null) Fridge.SetActive(true);

        StartSceneDialogue(new List<string> { "Picked up the smelly cheese. I should throw it away." });
    }

    public void OnKitchenTrashCanClick()
    {
        if (hasCheese && !cheeseThrownOut)
        {
            cheeseThrownOut = true;
            hasCheese = false;

            if (TrashBag != null)
            {
                TrashBag.SetActive(true);
                GameState.ShowTrashBag = true;
            }

            StartSceneDialogue(new List<string> { "I threw the smelly cheese in the trash. Now to take the trash out." });
        }
        else if (cheeseThrownOut && !GameState.TrashBagPickedUp)
        {
            StartSceneDialogue(new List<string> { "The trash is full. I need to take out the trash." });
        }
        else
        {
            StartSceneDialogue(new List<string> { "Nothing else to throw out." });
        }
    }

    public void OnTrashBagClick()
    {
        if (TrashBag != null) TrashBag.SetActive(false);

        GameState.TrashBagPickedUp = true;

        StartSceneDialogue(new List<string>
        {
            "Now I need to throw the trashbag into the outside trashcan and get back to the kitchen to do my homework."
        });
    }

    public void OnKitchenDoorClick()
    {
        SceneManager.LoadScene("FirstRoom");
    }

    public void OnFrontDoorClick()
    {
        SceneManager.LoadScene("OutHouse");
    }

    public void OnOutHouseTrashcanClick()
    {
        if (GameState.TrashBagPickedUp)
        {
            GameState.TrashTakenOut = true;

            StartSceneDialogue(new List<string> { "Tossed the trash in the bin. Now back to my homework!" });
        }
        else
        {
            StartSceneDialogue(new List<string> { "I should bring the trash out first." });
        }
    }

    public void OnTableClick()
    {
        if (!homeworkDone)
        {
            if (Homework != null) Homework.SetActive(true);
            StartSceneDialogue(new List<string> { "Homework time... let's solve this puzzle." });
        }
    }

    public void OnCompleteHomework()
    {
        homeworkDone = true;
        GameState.HomeworkDone = true;

        if (Homework != null) Homework.SetActive(false);

        StartSceneDialogue(new List<string> { "All done! Time to relax!" });
        SceneManager.LoadScene("EndScreen");
    }
}

