using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles the showing of debug objects when testing.
public class DebugVision : MonoBehaviour
{

    public static List<MeshRenderer> debugObjects = new List<MeshRenderer>();

    private bool inDebugMode = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            inDebugMode = !inDebugMode;

            foreach (MeshRenderer renderer in debugObjects)
            {
                renderer.enabled = inDebugMode;
            }
        }
	}
}
