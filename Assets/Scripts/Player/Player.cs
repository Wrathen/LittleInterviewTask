using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(PlayerAnimation))]
public class Player : MonoBehaviour {
    public PlayerMovement pMovement;
    public PlayerAnimation pAnimation;
    public float hp = 100f;
    public float maxHP = 100f;
    public float hpRegen = 0.3f;

    // Base Functions
    void Start() {
        GameManager.GetCamera().GetComponent<FollowTarget>()?.SetTarget(transform);
    }
    void Update() {
        RegenerateHealth();
    }

    // Main Functions
    void RegenerateHealth() {
        if (hp < maxHP) hp += hpRegen * Time.deltaTime;
        if (hp > maxHP) hp = maxHP;
    }
    public void TakeDamage(float amount) {
        hp -= amount;
        if (hp < 0) Die();
    }
    public void Die() { Application.Quit(0); }
}