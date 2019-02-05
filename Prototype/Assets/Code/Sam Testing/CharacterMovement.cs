using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    [SerializeField]
    float MovementSpeed = 1f;
    [SerializeField]
    float MaxSpeed = 10f;
    [SerializeField]
    float Sensititvity = 2f;
    [SerializeField]
    Transform CameraArm;
    [SerializeField]
    Rigidbody rbPlayer;
    [SerializeField]
    float JumpForce;

    int NumJumps = 2;

    // Gets current position of camera
    Vector2 MousePosition;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Moves the Player forward and backwards
        if (Input.GetKey(KeyCode.W))
        {
            //transform.Translate(Vector3.forward * MovementSpeed * Time.deltaTime);
            rbPlayer.AddRelativeForce(0, 0, MovementSpeed, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //transform.Translate(-Vector3.forward * MovementSpeed * Time.deltaTime);
            rbPlayer.AddRelativeForce(0, 0, -MovementSpeed, ForceMode.Impulse);
        }

        // Moves the player left or right
        if (Input.GetKey(KeyCode.D))
        {
            rbPlayer.AddRelativeForce(MovementSpeed, 0, 0, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rbPlayer.AddRelativeForce(-MovementSpeed, 0, 0, ForceMode.Impulse);
        }

        // Caps out the player's speed
        if (rbPlayer.velocity.magnitude > MaxSpeed)
        {
            rbPlayer.velocity = rbPlayer.velocity.normalized * MaxSpeed;
        }

        // Makes player Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Subtracts a jump every time the player jumps. Wont jump if no jumps are left
            if (NumJumps > 0)
            {
                rbPlayer.velocity = new Vector3(rbPlayer.velocity.x, 0);
                rbPlayer.AddForce(0, JumpForce, 0);
                NumJumps--;
            }
        }

        // Tests to see how much the mouse has moved
        Vector2 MouseChange = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        // Adds how much the mouse has moved to the current Position of the mouse times the Sensitivity
        MousePosition += MouseChange * Sensititvity;

        // Rotates the camera arm that is attached to the character
        CameraArm.transform.localRotation = Quaternion.AngleAxis(MousePosition.y, Vector3.left);

        // Rotates the character by how much the mouse moves left/right which also moves the camera
        this.transform.localRotation = Quaternion.AngleAxis(MousePosition.x, Vector3.up);
    }

    // gives the player jumps whenever the player collides with the ground
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            NumJumps = 2;
        }
    }
}
