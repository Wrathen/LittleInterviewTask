using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBehaviour : MonoBehaviour {
    public float maxDistanceFromSpawn = 300f;
    public float distanceThreshold = 150f;
    public float attackMoveSpeed = 2f;
    public float chaseSpeed = 5f;
    public float evadeSpeed = 12f;
    public float attackRange = 1f;
    public float attackDamage = 0.07f;
    public float attackSpeed = 0.17f;
    private float nextAttackTime = 0;

    public float distanceToTarget = 0f;
    public float distanceToSpawn = 0f;

    public bool isAttacking = false; // public for debugging
    public bool isChasing = false; // public for debugging
    public bool isEvading = false; // public for debugging

    private Rigidbody2D rb;
    private Transform target;
    private Player _targetPlayerScript;
    private Vector2 spawnPoint;
    private CapsuleCollider2D col;

    void Start() {
        target = GameManager.GetPlayer().transform;
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
        spawnPoint = transform.position;
    }
    void Update() {
        // State Machine Logic -- Checks
        if (target && !isEvading) {
            distanceToTarget = Vector3.Distance(transform.position, target.position);
            CheckState_Attack();
            CheckState_Chase();
        }
        CheckState_Evade();

        // State Machine Logic -- Behaviour
        if (isAttacking) DoState_Attack();
        else if (isChasing) DoState_Chase();
        else if (isEvading) DoState_Evade();
    }

    void Attack() {
        if (Time.time < nextAttackTime) return;
        if (!_targetPlayerScript) _targetPlayerScript = target.GetComponent<Player>();

        _targetPlayerScript.TakeDamage(attackDamage);
        nextAttackTime = Time.time + attackSpeed;
    }

    #region StateMachine
    // State Machine -- Checks
    void CheckState_Attack() {
        if (distanceToTarget < attackRange) {
            isAttacking = true;
            isChasing = false;
        } else isAttacking = false;
    }
    void CheckState_Chase() {
        if (!isAttacking && distanceToTarget < distanceThreshold)
            isChasing = true;
    }
    void CheckState_Evade() {
        distanceToSpawn = Vector2.Distance(transform.position.xy(), spawnPoint);
        if (distanceToSpawn > maxDistanceFromSpawn) {
            col.enabled = false;
            isEvading = true;
            isChasing = false;
            isAttacking = false;
        } else if (distanceToSpawn < 0.15f) {
            rb.velocity = Vector2.zero;
            col.enabled = true;
            isEvading = false;
        }
    }
    // State Machine -- Behaviour
    void DoState_Attack() {
        if (!target) return;
        Vector2 moveDir = (target.position.xy() - transform.position.xy()).normalized;
        rb.velocity = moveDir * attackMoveSpeed;
        Attack();
    }
    void DoState_Chase() {
        if (!target) return;
        Vector2 moveDir = (target.position.xy() - transform.position.xy()).normalized;
        rb.velocity = moveDir * chaseSpeed;
    }
    void DoState_Evade() {
        Vector2 moveDir = (spawnPoint - transform.position.xy()).normalized;
        rb.velocity = moveDir * evadeSpeed;
    }
    #endregion
}