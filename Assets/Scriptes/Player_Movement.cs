using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    //private Animator animator;
    private SpriteRenderer spriteRenderer;

    public float speed = 5f;
    private Vector2 moveDir;
    [HideInInspector] public Vector2 lastDir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastDir = Vector2.down;
    }


    void Update()
    {
        moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (moveDir.magnitude > 1f)
            moveDir.Normalize();

        if (moveDir.sqrMagnitude > 0.01f)
        {
            //animator.SetFloat("xMove", moveDir.x);
            //animator.SetFloat("yMove", moveDir.y);

            //flip character
            spriteRenderer.flipX = moveDir.x > 0f ? true : false;

            lastDir = moveDir;
        }
        //animator.SetBool("moving", moveDir.sqrMagnitude > 0.01f ? true : false);
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDir * speed * Time.fixedDeltaTime);
    }
}