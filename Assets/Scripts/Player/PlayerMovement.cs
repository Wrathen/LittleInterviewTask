using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private static bool isActive = true;
    private Rigidbody2D rb;

    public float speed;
    public Vector2 inputVec;
    public Vector3 velocity;

    void Awake() { rb = GetComponent<Rigidbody2D>(); if (!rb) Debug.LogError("No Rigidbody on Player!!"); }
    void Update() {
        // If deactivated, just return. Mostly UI will affect this variable.
        if (!isActive) {
            velocity = Vector3.zero;
            rb.velocity = Vector3.zero;
            return;
        }

        // Get Input
        inputVec = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        inputVec /= inputVec.magnitude + 0.00001f; // Avoid dividing by 0 by adding epsilon

        // Calculate & Update Velocities
        velocity = inputVec * speed * GlobalStats.moveSpeedModifier;
        rb.velocity = velocity;
    }

    public static void SetActive(bool flag) { isActive = flag; }
}