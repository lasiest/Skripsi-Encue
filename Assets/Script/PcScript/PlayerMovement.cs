using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 2f;
    public float gravity = -19.6f;
    public float jumpHeight = 1f;
    
    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;

    Vector3 velocity;
    public bool isGrounded;
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
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
