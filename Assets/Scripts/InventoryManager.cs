using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    private HashSet<string> inventoryItems = new HashSet<string>();

    void Awake()
    {
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

    public void AddItem(string itemName)
    {
        inventoryItems.Add(itemName);
        InventoryUI.Instance?.RefreshInventoryDisplay();
    }

    public bool HasItem(string itemName)
    {
        return inventoryItems.Contains(itemName);
    }

    public void RemoveItem(string itemName)
    {
        inventoryItems.Remove(itemName);
        InventoryUI.Instance?.RefreshInventoryDisplay();
    }

    public IEnumerable<string> GetItems()
    {
        return inventoryItems;
    }

    public void ClearInventory()
    {
        inventoryItems.Clear();

        if (InventoryUI.Instance != null)
            InventoryUI.Instance.RefreshInventoryDisplay();
    }

}

