using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Checkpoint : MonoBehaviour
{
    public int pointNumber;

    private void OnValidate()
    {
        if (pointNumber < 0)
        {
            pointNumber = -pointNumber;
        }
    }


    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
