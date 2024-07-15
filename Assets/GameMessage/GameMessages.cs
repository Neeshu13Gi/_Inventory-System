using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMessages : MonoBehaviour
{
    #region Singleton
    public static GameMessages instance;

    private void Awake()
    {
        if(instance != null)
        {
            return;
        }

        instance = this;
        
    }
    #endregion
    public GameObject message;

    public void Send(string text)
    {
        Instantiate(message, gameObject.transform).GetComponent<GameMessage>().GetComponent<Text>().text = text;
    }
}
