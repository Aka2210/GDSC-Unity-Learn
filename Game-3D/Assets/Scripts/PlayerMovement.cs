using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed = 5f;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask Ground;
    bool grounded;

    float horizontalInput;
    float verticalInput;
    [SerializeField] float JumpForce = 3;
    Vector3 moveDirection;
    Rigidbody rb;

    [SerializeField] Transform Orient;

    /*public enum MovementState
    {
        walking,
        sprinting,
        crouching,
        air
    }
    public MovementState state;
    */
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    private void FixedUpdate() 
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
      
        Vector3 forwardMovement = Orient.forward * verticalInput;
        Vector3 rightMovement = Orient.right * horizontalInput;

        moveDirection = (forwardMovement + rightMovement).normalized;
        Debug.Log(rb.velocity);
        rb.AddForce(moveDirection.normalized * walkSpeed, ForceMode.Force);
    }
    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(Orient.position, Vector3.down, playerHeight * 0.5f + 0.5f, Ground);
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Orient.up * JumpForce, ForceMode.Impulse);
        }
        SpeedControl();
    }

    void SpeedControl()
    {
        Vector3 Vel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (Vel.magnitude > walkSpeed)
        {
            Vector3 limitedVel = Vel.normalized * walkSpeed;
            rb.velocity = new UnityEngine.Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
