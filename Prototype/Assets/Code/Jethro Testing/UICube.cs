using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICube : MonoBehaviour {

    [SerializeField]
    private Text kEnergyOut;

    [SerializeField]
    private float minMagnitude;
    [SerializeField]
    private float maxMagnitude;

    [SerializeField]
    private Camera mainCam;

    [SerializeField]
    private Transform interfaceCube;

    [SerializeField]
    private Transform arrow;

    public float currentKineticEnergy = 0;
    public Vector3 currentKineticVelocity = Vector3.zero;

    // Use this for initialization
    void Start (){}
	
	// Update is called once per frame
	void Update ()
    {
        interfaceCube.rotation = Quaternion.Inverse(mainCam.transform.rotation);
	}

    public void UpdateCubeOrientation(Vector3 direction)
    {
        currentKineticVelocity = direction;
        arrow.LookAt(interfaceCube.TransformPoint(direction));
        currentKineticEnergy = Mathf.InverseLerp(minMagnitude, maxMagnitude, direction.magnitude) * 100;
        arrow.localScale = new Vector3(1, 1, Mathf.InverseLerp(minMagnitude, maxMagnitude, direction.magnitude));
        kEnergyOut.text = ((int)currentKineticEnergy).ToString();
    }
}
