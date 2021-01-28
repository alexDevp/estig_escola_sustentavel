using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController controller;
    
    public float speed = 12f;
    public float gravity = -19.62f;
    public float jumpHeight = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 fallVelocity;
    Vector3 move;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        Move();
        FreeFall();
        if (Input.GetButtonDown("Jump") && isGrounded()) {
            Jump();
        }
        
    }

    public void Move() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }
    public bool isGrounded() {
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
    public void FreeFall() {

        if (isGrounded() && fallVelocity.y < 0) {
            fallVelocity.y = -2f;
        }

        fallVelocity.y += gravity * Time.deltaTime;

        controller.Move(fallVelocity * Time.deltaTime);
    }

    public void Jump() {
        fallVelocity.y = Mathf.Sqrt(jumpHeight *-1f * gravity);
    }
}