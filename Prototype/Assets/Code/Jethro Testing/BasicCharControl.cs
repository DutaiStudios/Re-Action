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

    private WorldParser world;

    private Rigidbody playerRB;

    private bool debugVision = true;

	// Use this for initialization
	void Start ()
    {
        playerRB = gameObject.GetComponent<Rigidbody>();

        world = FindObjectOfType<WorldParser>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles += Vector3.down * turnSpeed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles += Vector3.up * turnSpeed * Time.fixedDeltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            playerRB.velocity = transform.forward * speed;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            debugVision = !debugVision;
            world.SetDebugVision(debugVision);
        }

        if (Input.GetMouseButton(2))
        {
            followCam.transform.eulerAngles += Input.GetAxis("Mouse Y") * Vector3.left * Time.fixedDeltaTime * panRate;
        }
    }
}
