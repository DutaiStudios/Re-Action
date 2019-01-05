using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiqVolume : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        other.GetComponent<Rigidbody>().AddForce(Vector3.up * Time.fixedDeltaTime * 15, ForceMode.Impulse);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
