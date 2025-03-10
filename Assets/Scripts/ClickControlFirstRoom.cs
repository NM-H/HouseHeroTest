using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        FreshPlant.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PickUpTowel()
    {
        hasTowel = true;
        NarrationTextFirstRoom.text = "You picked up the towel.";
        Towel.SetActive(false); // Hide the towel object
    }

    public void PickUpWaterCan()
    {
        hasWaterCan = true;
        NarrationTextFirstRoom.text = "You picked up the watering can.";
        WaterCan.SetActive(false); // Hide the water can object
    }

    public void CleanMud()
    {
        if (hasTowel && MudStain.activeSelf)
        {
            MudStain.SetActive(false);
            NarrationTextFirstRoom.text = "You cleaned the mud stain with the towel!";
        }
        else if (!hasTowel)
        {
            NarrationTextFirstRoom.text = "You need a towel to clean the mud.";
        }
    }

    public void WaterPlant()
    {
        if (hasWaterCan && DryPlant.activeSelf)
        {
            DryPlant.SetActive(false);
            FreshPlant.SetActive(true);
            NarrationTextFirstRoom.text = "You watered the plant, and it looks fresh now!";
        }
        else if (!hasWaterCan)
        {
            NarrationTextFirstRoom.text = "You need a watering can to water the plant.";
        }
    }
}

