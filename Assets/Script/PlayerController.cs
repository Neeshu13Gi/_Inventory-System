using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Inventory inventory;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    public float bulletSpeed = 10;
    public GameObject weapon; // Public reference to the weapon GameObject

    public Text bulletCountText; // Reference to the UI Text component

    private int currentBullets = 0;
    private int maxBullets = 20; // Maximum bullets player can carry
    public Button shootButton;

    // Reference to the "Shoot" button

    void Start()
    {
        // Ensure the weapon starts disabled
        if (weapon != null)
        {
            weapon.SetActive(false);
        }

        // Initialize bullet count text
        UpdateBulletCountText();

        if (shootButton != null)
        {
            shootButton.interactable = false;
        }
    }

    void UseWeapon()
    {
        Item weaponItem = inventory.items.Find(item => item.itemType == ItemType.Weapon);

        if (weaponItem != null)
        {

            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            DecreaseBulletCount();
        }
    }

    public void Fire()
    {
        if (currentBullets > 0)
        {
            UseWeapon();
        }
        else
        {
            Debug.Log("No bullets left to fire!");
            shootButton.interactable = false;
        }
    }

    // Method to update bullet count text
    void UpdateBulletCountText()
    {
        if (bulletCountText != null)
        {
            bulletCountText.text = "Bullets: " + currentBullets.ToString();
        }
    }

    // Method to increase bullet count (called when picking up bullets)
    public void IncreaseBulletCount(int amount)
    {
        currentBullets += amount;
        if (currentBullets > maxBullets)
        {
            currentBullets = maxBullets;
        }
        UpdateBulletCountText();
        CheckShootButtonInteractable(); // Check if shoot button should be interactable
    }

    // Method to set bullet count to a specific value
    public void SetBulletCount(int amount)
    {
        currentBullets = amount;
        UpdateBulletCountText();
        CheckShootButtonInteractable(); // Check if shoot button should be interactable
    }

    // Method to decrease bullet count (called when firing)
    public void DecreaseBulletCount()
    {
        currentBullets--;
        if (currentBullets < 0)
        {
            currentBullets = 0;
        }
        UpdateBulletCountText();
        CheckShootButtonInteractable(); // Check if shoot button should be interactable
    }

    // Method to check if the shoot button should be interactable
    public void CheckShootButtonInteractable()
    {
        if (shootButton != null)
        {
            bool hasWeapon = (weapon != null && weapon.activeInHierarchy); // Check if weapon is active
            shootButton.interactable = (hasWeapon && currentBullets > 0);
        }
    }

    public void EnableShootButton(bool enable)
    {
        if (shootButton != null)
        {
            shootButton.interactable = enable;
        }
    }
}
