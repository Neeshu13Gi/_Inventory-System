using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        Destroy(gameObject, 2f); // Destroy bullet after 2 seconds
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject); // Destroy bullet on collision
    }


  
}