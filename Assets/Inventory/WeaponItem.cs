

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory/Weapon")]
public class WeaponItem : Item
{
    
    public override void Use()
    {
        // Find the player GameObject with the "Player" tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player GameObject not found with tag 'Player'.");
            return;
        }

        // Find the BulletSpawn as a child of the player GameObject
        Transform bulletSpawn = player.transform.Find("BulletSpawn");
        if (bulletSpawn == null)
        {
            Debug.LogError("BulletSpawn not found as a child of the player GameObject.");
            return;
        }

        // Proceed with firing logic
        if (Inventory.instance.ConsumeItem(ItemType.Bullet))
        {
            if (prefOutHand == null)
            {
                Debug.LogError("prefOutHand is not assigned in WeaponItem.");
                return;
            }

            // Instantiate the bullet prefab at the BulletSpawn position and rotation
            GameObject bullet = Instantiate(prefOutHand, bulletSpawn.position, bulletSpawn.rotation);
            Debug.Log("Firing " + name); // Use 'name' instead of 'itemName'
        }
        else
        {
            Debug.Log("No bullets left!");
        }
    }

}
