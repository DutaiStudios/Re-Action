using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Define an enum to represent the current state of this magnetic object.
// TODO perhaps these classes should be granted their own namespace for encapsulation.
public enum MagneticPole
{
    noPole, north, south
}

public class MagneticProperty : MonoBehaviour
{
    [SerializeField]
    public float influenceRadius;

    [SerializeField]
    public MagneticPole currentPole;

    private WorldParser world;

    private float force = 15;

    // Call start to locate the world parser.
    private void Start()
    {
        // Locate the world parser in the scene.
        world = FindObjectOfType<WorldParser>();

        // Add this instance to the world so other magnets can see it.
        world.magneticObjects.Add(this);
    }

    // Call on destroy to keep the world up to date.
    private void OnDestroy()
    {
        // Remove this instance from the current magnets.
        world.magneticObjects.Remove(this);
    }

    // Call fixed update to apply magnetic forces.
    void FixedUpdate ()
    {
        // Is this object able to act on other magnetic objects?
		if (currentPole != MagneticPole.noPole)
        {
            // Cycle through other magnetic objects.
            foreach(MagneticProperty otherMagnet in world.magneticObjects)
            {
                // Will the other object have a magnetic reaction?
                if (otherMagnet.currentPole != MagneticPole.noPole)
                {
                    // Is the other object inside the radius of influence?
                    if (Vector3.Distance(otherMagnet.transform.position, transform.position) < influenceRadius)
                    {
                        // Do these objects have the same pole?
                        if (otherMagnet.currentPole == currentPole)
                        {
                            // Repell the other object.
                            otherMagnet.GetComponent<Rigidbody>().AddForce(Vector3.Normalize(otherMagnet.transform.position - transform.position) * Time.fixedDeltaTime * force, ForceMode.Impulse);
                        }
                        else
                        {
                            // Attract the other object.
                            otherMagnet.GetComponent<Rigidbody>().AddForce(Vector3.Normalize(transform.position - otherMagnet.transform.position) * Time.fixedDeltaTime * force, ForceMode.Impulse);
                        }
                    }
                }
            }
        }
	}

    /*
     * Development only stuff. 
    */
    
#if DEBUG
    private void OnDrawGizmosSelected()
    {
        // When the object is selected, draw a wire sphere to show the influence.
        Gizmos.DrawWireSphere(transform.position, influenceRadius);
    }

    private void OnValidate()
    {
        // (Sanity Check)Ensure that the influence radius is positive.
        influenceRadius = Mathf.Abs(influenceRadius);
    }
#endif
}