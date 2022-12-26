using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float movementSpeed = 3.2f;  // Movement speed of player
    public Vector2 movement;  // Movement axis of player
    public Rigidbody2D rigidbody;  // The rigidbody component

    public Animator animator;  // The Animator controller
    public float hf = 0.0f;
    public float vf = 0.0f;
    private bool goingUp = false;
    private bool goingLeft = false;
    private bool goingRight = false;
    private bool goingDown = true;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;
        hf = movement.x > 0.01f ? movement.x : movement.x < -0.01f ? 1 : 0;
        vf = movement.y > 0.01f ? movement.y : movement.y < -0.01f ? 1 : 0;
        if (movement.x < -0.01f)
        {
            this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            goingLeft = true;
            goingRight = false;
            goingUp = false;
            goingDown = false;
        }
        else
        {
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
            goingRight = true;
            if (movement.x > 0.01f)
            {
                goingLeft = false;
                goingUp = false;
                goingDown = false;
            }
        }
        if (movement.y > 0.01f)
        {
            goingUp = true;
            goingLeft = false;
            goingRight = false;
            goingDown = false;
        } 
        else if (movement.y < -0.01f)
        {
            goingUp = false;
            goingLeft = false;
            goingRight = false;
            goingDown = true;
        }
        if (hf == 0)
        {
            if (goingLeft)
            {
                this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        animator.SetFloat("Horizontal", hf);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", vf);
        animator.SetBool("GoingUp", goingUp);
        animator.SetBool("GoingSide", goingLeft || goingRight);
        animator.SetBool("GoingDown", goingDown);
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
