using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMessage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObj", 0);
    }

    // Update is called once per frame
   void DestroyObj()
    {
        Destroy(gameObject);
    }
}
