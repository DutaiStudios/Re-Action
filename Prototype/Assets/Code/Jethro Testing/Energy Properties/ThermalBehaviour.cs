using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if DEBUG
using UnityEditor;
#endif

/// <summary>This class is for assigning thermal behaviours to objects</summary>
public class ThermalBehaviour : MonoBehaviour
{

    [SerializeField]
    public bool canExplode;

    [Header("Explosion Properties")]

    [SerializeField]
    private float explosionMagnitude;

    [SerializeField]
    private float explosionRadius;

    // When the scene is loaded, objects will have appropriate behaviours generated.
    void Start ()
    {
		
	}
}

[CustomEditor(typeof(ThermalBehaviour))]
public class MyScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var myScript = target as ThermalBehaviour;

        myScript.canExplode = GUILayout.Toggle(myScript.canExplode, " Can Explode");

        if (myScript.canExplode)
        {
            GUILayout.Label("Explosion Properties");

            GUILayout.TextField("Input");
        }
    }
}
