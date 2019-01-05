using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyTool : MonoBehaviour
{
    // Bools to track which energies are currently available.
    private bool kineticEnergyUnlocked;
    private bool thermalEnergyUnlocked;
    private bool magneticEnergyUnlocked;



    bool timeSlow = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.T))
        {
            timeSlow = !timeSlow;

            if (timeSlow)
            {
                Time.timeScale = 0.1f;
            }
            else
            {
                Time.timeScale = 1;
            }

            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
	}
}
