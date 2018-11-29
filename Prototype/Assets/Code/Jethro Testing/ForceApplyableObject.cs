using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceApplyableObject : MonoBehaviour {

    private UICube cube;
    private Rigidbody thisBody;

	// Use this for initialization
	void Start ()
    {
        thisBody = gameObject.GetComponent<Rigidbody>();
        cube = GameObject.Find("UICube").GetComponent<UICube>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    private void OnMouseEnter()
    {
        
    }

    private void OnMouseExit()
    {
        
    }

    private void OnMouseDown()
    {
        thisBody.velocity = cube.currentKineticVelocity;
        cube.UpdateCubeOrientation(Vector3.zero);
    }
}
