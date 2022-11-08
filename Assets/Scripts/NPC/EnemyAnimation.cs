using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D), typeof(EnemyBehaviour))]
public class EnemyAnimation : MonoBehaviour {
    private Rigidbody2D rb;
    private Animator animator;
    private EnemyBehaviour behaviour;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        behaviour = GetComponent<EnemyBehaviour>();
    }

    // I think this setup works much better than multiple booleans
    void Update() {
        if (IsMovingLeft()) transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 180, transform.localEulerAngles.z);
        else transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, transform.localEulerAngles.z);

        animator.SetInteger("ActionState", GetActionState());
    }

    int GetActionState() { return IsAttacking() ? 3 : IsMovingRight() ? 2 : IsMovingLeft() ? 1 : 0; }
    bool IsMovingLeft() { return rb.velocity.x < 0.0f; }
    bool IsMovingRight() { return rb.velocity.x > 0.0f; }
    bool IsAttacking() { return behaviour.isAttacking; }
}