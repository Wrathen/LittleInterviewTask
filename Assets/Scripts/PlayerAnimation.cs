using UnityEngine;

[RequireComponent(typeof(Animator), typeof(PlayerMovement))]
public class PlayerAnimation : MonoBehaviour {
    private Animator animator;
    private PlayerMovement playerMovement;

    void Awake() {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // I think this setup works much better than multiple booleans
    void Update() { animator.SetInteger("MoveDirection", GetMoveDirection()); }

    int GetMoveDirection() { return IsMovingUp() ? 1 : IsMovingDown() ? 2 : IsMovingRight() ? 3 : IsMovingLeft() ? 4 : 0; }
    bool IsMovingLeft() { return playerMovement.velocity.x < 0.0f; }
    bool IsMovingRight() { return playerMovement.velocity.x > 0.0f; }
    bool IsMovingUp() { return playerMovement.velocity.y > 0.0f; }
    bool IsMovingDown() { return playerMovement.velocity.y < 0.0f; }
}