using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOBCollision : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        // Is the colliding object a force applicable object?
        if (collision.gameObject.GetComponent<ForceApplyableObject>())
        {
            // Destroy the colliding object.
            Destroy(collision.gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
