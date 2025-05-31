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

    private HashSet<string> itemsCollected = new HashSet<string>();

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddItem(string itemName, Sprite itemIcon)
    {
        if (itemsCollected.Contains(itemName)) return; // Prevent duplicates

        GameObject slot = Instantiate(inventorySlotPrefab, slotContainer);
        slot.GetComponentInChildren<Image>().sprite = itemIcon;
        itemsCollected.Add(itemName);
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
        // Clear existing slots
        foreach (Transform child in slotContainer)
        {
            Destroy(child.gameObject);
        }

        // Re-add items from the InventoryManager
        foreach (string itemName in InventoryManager.Instance.GetItems())
        {
            Sprite icon = GetIconForItem(itemName);
            if (icon != null)
            {
                AddItem(itemName, icon);
            }
        }
    }
}
