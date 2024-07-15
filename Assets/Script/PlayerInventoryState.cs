using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryState : MonoBehaviour
{
    public static PlayerInventoryState instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public bool hasWeapon = false;
}
