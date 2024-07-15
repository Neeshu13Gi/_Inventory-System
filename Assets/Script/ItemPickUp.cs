
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickUp : MonoBehaviour
{
    public Item item;
    public GameObject parent;
    private Button buttonPickUp;

    void Start()
    {
        buttonPickUp = GameObject.FindGameObjectWithTag("PickUp").GetComponent<Button>();
    }
    void PickUp()
    {
        buttonPickUp.interactable = false;
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
        {
            PlayerController playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            if (playerController != null)
            {
                if (item.itemType == ItemType.Weapon)
                {
                    if (playerController.weapon != null)
                    {
                        playerController.weapon.SetActive(true); // Enable the weapon
                        PlayerInventoryState.instance.hasWeapon = true;
                    }
                    else
                    {
                        Debug.LogError("Player controller or weapon reference not found!");
                    }
                }
                else if (item.itemType == ItemType.Bullet)
                {
                    playerController.SetBulletCount(20); // Set bullet count to 20
                }

                // Update the shoot button state in the PlayerController
                playerController.CheckShootButtonInteractable();
            }

            Destroy(parent);
        }
    }

   

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            // Check if the player has a weapon
            if (PlayerInventoryState.instance.hasWeapon && item.itemType == ItemType.Weapon)
            {
                buttonPickUp.interactable = false; // Disable pickup for a second weapon
            }
            else
            {
                buttonPickUp.onClick.RemoveAllListeners();
                buttonPickUp.onClick.AddListener(PickUp);
                buttonPickUp.interactable = true;
            }

            // Check if the player has a weapon and the item is not a weapon
            if (PlayerInventoryState.instance.hasWeapon && item.itemType != ItemType.Weapon)
            {
                buttonPickUp.interactable = true; // Disable pickup for non-bullet items if player has a weapon
            }

            //buttonPickUp.onClick.RemoveAllListeners();
            //    buttonPickUp.onClick.AddListener(PickUp);
            //    buttonPickUp.interactable = true;
           
        }



    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            buttonPickUp.onClick.RemoveListener(PickUp);
            buttonPickUp.interactable = false;
        }
    }
}