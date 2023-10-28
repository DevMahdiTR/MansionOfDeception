using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;

    private Vector2 moveDirection;

    private void Update()
    {
        ProcessInputs();
    }


    private void FixedUpdate()
    {
        Move();
    }

    private void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;


        if(moveX == 0 && moveY == 0)
        {
            anim.SetBool("isMoving", false);
        }

        if (moveX > 0)
        {
            anim.SetFloat("Direction", 2);
            anim.SetBool("isMoving", true);
        }
        else if (moveX < 0)
        {
            anim.SetFloat("Direction", 3);
            anim.SetBool("isMoving", true);
        }
        if (moveY > 0)
        {


            anim.SetFloat("Direction", 1);
            anim.SetBool("isMoving", true);
        } 
        else if (moveY < 0)
        {
            anim.SetBool("isMoving", true);
            anim.SetFloat("Direction", 0);
        }

    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

}
