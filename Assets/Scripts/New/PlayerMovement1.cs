using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public float speed = 10f;
    public CharacterController controller;
    public Transform groundCheck;
    public float gravity = 9.8f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    public Animator anim;

    private Vector3 velocity;
    private bool isGrounded;
    private float playerSpeed;

    void Start()
    {
        playerSpeed = speed;
    }

        // Update is called once per frame
        void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (controller.isGrounded)
        {
            anim.SetFloat("x", Input.GetAxis("Horizontal"));
            anim.SetFloat("y", Input.GetAxis("Vertical"));
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime / 2);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
            anim.SetTrigger("Jump");
            Debug.Log("Jump");
        }
        else if(!isGrounded)
        {
            anim.SetBool("Fall", true);
        }
        else
        {
            anim.SetBool("Fall", false);
        }
        /*
        if(Input.GetKey(KeyCode.LeftControl))
        {
            controller.height = 0.9f;
        }
        else 
        {
            controller.height = 1.8f;
        }
        */
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = playerSpeed * 2;
            anim.SetFloat("y", Input.GetAxis("Vertical") * 2);
        }
        else
        {
            speed = playerSpeed;
        }
    }
}
