using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For debug testing only.
public class BoxMovement : MonoBehaviour {

    public Vector3 velocity;

    private UICube cube;

    // Use this for initialization
    void Start ()
    {
        cube = GameObject.Find("UICube").GetComponent<UICube>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        velocity = Vector3.left * 5 * Mathf.Cos(Time.time);
        transform.position += velocity * Time.deltaTime;
	}

    private void OnMouseDown()
    {
        cube.UpdateCubeOrientation(velocity);
    }
}
