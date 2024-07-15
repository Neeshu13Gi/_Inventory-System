using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;   // Reference to the parent object of inventory slots
    public GameObject inventoryUI;  // Renamed from 'InventoryUI' to avoid conflicts

    Inventory inventory;         // Reference to the Inventory instance
    InventorySlot[] slots;       // Array of InventorySlot components

    void Start()
    {
        inventory = Inventory.instance;   // Get the instance of the Inventory class
        inventory.onItemChangedCallBack += UpdateUI;  // Subscribe to the item changed event
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();  // Get all InventorySlot components from the itemsParent
        //UpdateUI();
        // Initialize the UI to reflect the current state of the inventory
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);  // Add item to the slot
            }
            else
            {
                slots[i].ClearSlot();  // Clear the slot if there is no item
            }
        }
    }

    public void ClickInventoryButton()
    {
        if (inventoryUI.activeSelf)
        {
            inventoryUI.SetActive(false);  // Hide the inventory UI
        }
        else
        {
            UpdateUI();  // Update the UI
            inventoryUI.SetActive(true);  // Show the inventory UI
        }
    }
}
