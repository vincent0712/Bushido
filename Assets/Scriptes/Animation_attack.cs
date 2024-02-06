using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator animator;
    Vector2 attackDirection;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Example input handling (modify according to your input system)
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Set attack direction based on input
        attackDirection = new Vector2(horizontalInput, verticalInput).normalized;

        if (Input.GetKeyDown(KeyCode.Mouse0)) // Assuming left mouse button is used for attack
        {
            Attack();
        }
    }

    void Attack()
    {
        // Calculate the angle of attack direction relative to the right direction
        float angle = Vector2.SignedAngle(Vector2.right, attackDirection);

        // Convert angle to direction index (0 = right, 1 = up, 2 = left, 3 = down)
        int directionIndex = Mathf.RoundToInt((angle / 90f) + 1.5f) % 4;

        // Set the "Direction" parameter in the Animator to trigger the appropriate attack animation
        animator.SetInteger("Direction", directionIndex);
        animator.SetTrigger("Attack");
    }
}