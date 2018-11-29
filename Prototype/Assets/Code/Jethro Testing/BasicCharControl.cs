using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// For debug testing only.
public class BasicCharControl : MonoBehaviour {

    [SerializeField]
    private float panRate;

    [SerializeField]
    private Camera followCam;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float turnSpeed;

    private Rigidbody playerRB;

	// Use this for initialization
	void Start ()
    {
        playerRB = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles += Vector3.down * turnSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles += Vector3.up * turnSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            playerRB.velocity = transform.forward * speed;
        }

        if (Input.GetMouseButton(2))
        {
            followCam.transform.eulerAngles += Input.GetAxis("Mouse Y") * Vector3.left * Time.deltaTime * panRate;
        }
    }
}
