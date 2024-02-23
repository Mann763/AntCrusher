using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    public List<Transform> objectsToRotate; // List of objects to be rotated

    public float rotationSpeed = 60.0f; // Rotation speed in degrees per second

    void Update()
    {
        foreach (Transform objTransform in objectsToRotate)
        {
            // Generate random rotation in each frame
            float randomRotation = Random.Range(0, 360);
            Quaternion newRotation = Quaternion.Euler(0, 0, randomRotation);

            // Rotate the object
            objTransform.rotation = Quaternion.RotateTowards(objTransform.rotation, newRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
