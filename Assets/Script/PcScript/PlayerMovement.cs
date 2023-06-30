using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.8f;
    public float jumpHeight = 5f;
    
    public Transform groundCheck;
    public float gorundDistance = 0.2f;
    public LayerMask groundMask;

    Vector3 velocity;
    public bool isGrounded;
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, gorundDistance, groundMask);
        if(isGrounded && velocity.y < 0){
            velocity.y = 0f;
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * y;
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            Debug.Log("Pressed Jump");
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
