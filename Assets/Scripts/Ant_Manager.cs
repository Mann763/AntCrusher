using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ant_Manager : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 180.0f; // Rotation speed in degrees per second

    [SerializeField] private GameObject[] Effect;

    public int pointsOnDestroy = 10;

    private void Update()
    {
        MoveObject();
    }

    private void MoveObject()
    {
        Vector3 movement = Vector3.up * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BoundingBox"))
        {
            Debug.Log("Collided");
            FlipRotation();
        }
    }

    private void FlipRotation()
    {
        // Flip the rotation by 180 degrees
        Vector3 newRotation = transform.eulerAngles;
        newRotation.z += 180.0f;
        transform.eulerAngles = newRotation;
    }

    private void OnMouseDown()
    {
        Gamemanager.instance.AddScore(pointsOnDestroy);
        SoundManager.instance.Play("AntSquish");
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Instantiate(Effect[0], transform.position, Quaternion.identity);
        Instantiate(Effect[1], transform.position, Quaternion.identity);
    }
}
