using UnityEngine;
using System.Collections.Generic;

public class AutoRotate : MonoBehaviour
{
    // List of GameObjects to rotate
    public List<GameObject> objectsToRotate;

    // Rotation speed
    public float rotationSpeed = 10f;

    void Update()
    {
        // Rotate each GameObject in the list
        foreach (GameObject obj in objectsToRotate)
        {
            if (obj != null) // Check if the GameObject is not null
            {
                obj.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
            }
        }
    }
}
