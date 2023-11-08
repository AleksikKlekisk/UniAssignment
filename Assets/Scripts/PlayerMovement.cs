using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerInputManager inputManager;
    [SerializeField] CharacterController controller;
    Vector3 velocity;
    [SerializeField] float gravity = -9.81f;
    bool isGrounded;
    [SerializeField] float speed = 12f;
    [SerializeField] float jumpHeight = 3f;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    public LayerMask groundMask;
    public AudioSource SoundManager;
    public AudioClip jumpSound;
    void Start()
    {
        inputManager = PlayerInputManager.Instance;
    }

    
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        float x = inputManager.GetPlayerMovement().x;
        float y = inputManager.GetPlayerMovement().y;
        bool jump = inputManager.HasPlayerJumped();

        Vector3 move = transform.right * x + transform.forward * y;

        //jump
        if(jump && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            SoundManager.PlayOneShot(jumpSound);
        }
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
