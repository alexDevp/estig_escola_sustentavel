using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController controller;
    
    public float speed = 12f;
    public float gravity = -40f;
    public float jumpHeight = 2.9f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 fallVelocity;
    Vector3 move;

    private FootstepSound player_Footsteps;
    private float walk_volume_Min = 0.1f;
    private float walk_volume_Max = 1f;
    private float walk_Step_Distance = 0.3f;

    // Start is called before the first frame update
    void Start() {
        player_Footsteps.volume_Min = walk_volume_Min;
        player_Footsteps.volume_Max = walk_volume_Max;
        player_Footsteps.step_Distance = walk_Step_Distance;
    }

    void Awake()
    {
        player_Footsteps = GetComponentInChildren<FootstepSound>();
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