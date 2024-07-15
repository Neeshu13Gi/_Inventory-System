using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    public void Awake()
    {
        if(instance!= null)
        {
            Debug.Log("Inventory is full");
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();

    public OnItemChanged onItemChangedCallBack;

    private int space = 20;
    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if(items.Count >= space)
            {

                GameMessages.instance.Send("Inventory is full now");
                Debug.Log("Not Enough room");
                return false;
            }
            GameMessages.instance.Send("+" + item.name);
            items.Add(item);

            if(onItemChangedCallBack != null)
            {
                onItemChangedCallBack.Invoke();

            }
           
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if(onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke();
        }
        if (item.itemType == ItemType.Weapon)
        {
            PlayerController playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            playerController.weapon.SetActive(false); 
          PlayerInventoryState.instance.hasWeapon = false; // Reset weapon state
        }
    }
    public bool ConsumeItem(ItemType itemType)
    {
        Item itemToConsume = items.Find(item => item.itemType == itemType);
        if (itemToConsume != null)
        {
            Remove(itemToConsume);
            return true;
        }
        return false;
    }

}
