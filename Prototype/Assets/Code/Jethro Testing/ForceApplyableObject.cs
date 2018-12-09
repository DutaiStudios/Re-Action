using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceApplyableObject : MonoBehaviour
{

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

    // When the player clicks on this object.
    private void OnMouseDown()
    {
        // Is there no energy stored? Take Energy.
        if (cube.currentKineticEnergy == 0)
        {
            Debug.Log("Took Energy: " + thisBody.velocity.y);
            cube.UpdateCubeOrientation(thisBody.velocity);
        }
        // Exert energy.
        else
        {
            Debug.Log("Exerted Energy");
            thisBody.velocity = cube.currentKineticVelocity;
            cube.currentKineticEnergy = 0;
            cube.UpdateCubeOrientation(Vector3.zero);
        }
    }
}
