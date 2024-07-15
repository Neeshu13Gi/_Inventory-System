using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;

    Item item;

    public void AddItem(Item newItem)
    {


        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;

    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;

    }
   

    public void OnRemoveButton()
    {
        if (item.itemType == ItemType.Weapon)
        {
            PlayerInventoryState.instance.hasWeapon = false; // Reset weapon state
        }

        Instantiate(item.prefOutHand, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity);
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        item.Use();
    }
}
