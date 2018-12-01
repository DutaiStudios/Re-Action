using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    [SerializeField]
    float MovementSpeed = 5f;
    [SerializeField]
    float Sensititvity = 2f;
    [SerializeField]
    Transform CameraArm;

    // Gets current position of camera
    Vector2 MousePosition;

    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Moves the Player forward and backwards
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * MovementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * MovementSpeed * Time.deltaTime);
        }

        // Moves the player left or right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * MovementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Vector3.right * MovementSpeed * Time.deltaTime);
        }

        // Makes player Jump
        if (Input.GetKey(KeyCode.Space))
        {
            
        }

        // Tests to see how much the mouse has moved
        Vector2 MouseChange = new Vector2 (Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        // Adds how much the mouse has moved to the current Position of the mouse times the Sensitivity
        MousePosition += MouseChange * Sensititvity;

        // Rotates the camera arm that is attached to the character
        CameraArm.transform.localRotation = Quaternion.AngleAxis(MousePosition.y, Vector3.left);

        // Rotates the character by how much the mouse moves left/right which also moves the camera
        this.transform.localRotation = Quaternion.AngleAxis(MousePosition.x, Vector3.up);
    }
}
