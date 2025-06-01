// Updated InventoryUI script to persist across scenes
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;

    public GameObject inventorySlotPrefab;
    public Transform slotContainer;
    public CanvasGroup canvasGroup;
    public Sprite keyIcon, towelIcon, wateringCanIcon, cheeseIcon, trashbagIcon;

    private Sprite GetIconForItem(string itemName)
    {
        switch (itemName)
        {
            case "Key": return keyIcon;
            case "Towel": return towelIcon;
            case "WateringCan": return wateringCanIcon;
            case "Cheese": return cheeseIcon;
            case "Trashbag": return trashbagIcon;
            default: return null;
        }
    }

    void Awake()
    {
        // Make InventoryUI persist across scenes
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {
        // Refresh inventory display when scene loads
        RefreshInventoryDisplay();
    }

    private void AddItemSlot(string itemName, Sprite itemIcon)
    {
        GameObject slot = Instantiate(inventorySlotPrefab, slotContainer);
        slot.GetComponentInChildren<Image>().sprite = itemIcon;
    }

    public void ShowInventory()
    {
        canvasGroup.alpha = 1;
    }

    public void HideInventory()
    {
        canvasGroup.alpha = 0;
    }

    public void RefreshInventoryDisplay()
    {
        // Safely clear existing slots
        if (slotContainer != null)
        {
            foreach (Transform child in slotContainer)
            {
                if (child != null)
                    Destroy(child.gameObject);
            }
        }

        // Re-add items from the InventoryManager
        if (InventoryManager.Instance != null)
        {
            foreach (string itemName in InventoryManager.Instance.GetItems())
            {
                Sprite icon = GetIconForItem(itemName);
                if (icon != null)
                {
                    AddItemSlot(itemName, icon);
                }
            }
        }
    }

}