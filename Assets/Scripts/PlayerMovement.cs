using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody2D rb;

    public float speed;
    public Vector2 inputVec;
    public Vector3 velocity;

    void Awake() { rb = GetComponent<Rigidbody2D>(); if (!rb) Debug.LogError("No Rigidbody on Player!!"); }
    void Update() {
        // Get Input
        inputVec = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        inputVec /= inputVec.magnitude + 0.00001f; // Avoid dividing by 0 by adding epsilon

        // Calculate Velocity
        velocity = inputVec * speed;

        // Update Rigidbody Velocity
        rb.velocity = velocity;
    }
}