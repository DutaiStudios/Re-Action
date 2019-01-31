using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifespanProperty : MonoBehaviour
{
    [SerializeField]
    private float lifeSpan;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        lifeSpan -= Time.deltaTime;
        if (lifeSpan < 0)
        {
            Destroy(gameObject);
        }
	}
}
