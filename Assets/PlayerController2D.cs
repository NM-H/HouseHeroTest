using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get Rigidbody2D component
    }

    void FixedUpdate()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Convert mouse position to world coordinates
        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized; // Get direction towards mouse
        rb.velocity = direction * moveSpeed; // Move player
    }
}
