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

    private Vector3 startZone;

    // Base Functions
    void Start() {
        GameManager.GetCamera().GetComponent<FollowTarget>()?.SetTarget(transform);
        startZone = transform.position;
    }
    void Update() {
        // Teleport Skill
        if (GlobalStats.canTeleport &&
            Time.time > GlobalStats.nextTeleportTime &&
            Input.GetKeyDown(KeyCode.Space)) {
                transform.position = startZone;
                GlobalStats.nextTeleportTime = Time.time + GlobalStats.teleportCooldown;
            }

        // Regen
        RegenerateHealth();
    }

    // Main Functions
    public void Die() { Application.Quit(0); }
    public void TakeDamage(float amount) {
        hp -= amount;
        if (hp < 0) Die();
    }
    void RegenerateHealth() {
        if (hp < maxHP) hp += hpRegen * Time.deltaTime;
        if (hp > maxHP) hp = maxHP;
    }
}