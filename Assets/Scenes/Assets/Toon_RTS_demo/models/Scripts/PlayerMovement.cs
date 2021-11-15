using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // VARIABLES
    
    [SerializeField] private float walkSpeed;
    
    [SerializeField] private float moveSpeed;
    
    [SerializeField] private float runSpeed;

    [SerializeField] private bool isGrounded;

    [SerializeField] private float groundCheckDistance;

    [SerializeField] private LayerMask groundMask;

    [SerializeField] private float gravity;

    [SerializeField] private float jumpHeight;
    private Vector3 moveDirection;

    private Vector3 velocity;


    // REFERENCES 
    private CharacterController controller;
    private Animator anim;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();       
    }
    
    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(moveX, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);

        if (isGrounded)
        {
            // If statement for our character to walk
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {

                // Walk code
                walk();

            }
            // If statement for our character to run
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                // Run code
                run();
                Debug.Log("Left Shift basýyo");
            }
            // If idle
            else if (moveDirection == Vector3.zero)
            {
                // Idle code
                idle();

            }

            moveDirection *= moveSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump();
            }

        }
        
        
        controller.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    
    
    
    }
    private void idle()
    {
        anim.SetFloat("Speed", 0);
    }

    private void walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed",0.5f);

    }
    
    private void run()
    {
        moveSpeed = runSpeed;
        anim.SetFloat("Speed", 1f);
    }

    private void jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }



}
