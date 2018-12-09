using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Logic for spawning objects in game during runtime.
public class ObjFactory : MonoBehaviour
{
    [SerializeField]
    private Vector3 spawnVelocity;

    [SerializeField]
    private GameObject toProduce;

    [SerializeField]
    private float productionRate;


    private float lastProductionTime;

	// Use this for initialization
	private void Start ()
    {
        lastProductionTime = Time.time;

		if (toProduce == null)
        {
            Destroy(this);
        }
	}

    private void Update()
    {
        // Is it time to produce another object?
        if (Time.time - lastProductionTime > productionRate)
        {
            // Update the last production time to now.
            lastProductionTime = Time.time;

            // Create the new object from the prefab.
            GameObject newInstance = Instantiate(toProduce, transform.position, Quaternion.identity);

            // Apply the intial velocity to this object.
            newInstance.GetComponent<Rigidbody>().AddForce(spawnVelocity, ForceMode.Impulse);
        }
    }
}
