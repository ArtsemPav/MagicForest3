using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform GroundCheck;
    public Transform WaterCheck;
    public LayerMask groundMask;
    public LayerMask waterMask;
    public float speed1 = 10f;
    public float gravity = 9.8f;
    public float playerHeight = 1.8f;

    public float jumpHieght = 3f;
    public float groundDistance = 0.4f;
    public Animator anim;

    Vector3 velocity;

    private bool isGrounded;
    private bool isWatered;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = speed1;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if(controller.isGrounded)
        {
            anim.SetFloat("X", Input.GetAxis("Horizontal"));
            anim.SetFloat("Y", Input.GetAxis("Vertical"));
        }
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Jump
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHieght * gravity);
            anim.SetTrigger("Jump");
            Debug.Log("Jump");
        }

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //squatted down
        if (Input.GetKey(KeyCode.LeftControl))
        {
            controller.height = playerHeight/2;
            Debug.Log("squatted down");
        }
        else
        {
            controller.height = playerHeight;
        }

        //Sprint
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 2 * speed1;
            anim.SetFloat("Y", 2);
            Debug.Log(speed);
        }
        else 
        {
            speed = speed1;
        }
    }
}
