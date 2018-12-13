using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


// Logic for spawning objects in game during runtime.
public class ObjFactory : MonoBehaviour
{

    public int pointNumber;

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
        // Set the last production time to now.
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

            // Produce a new instance.
            Produce();
        }
    }

    /// <summary>Makes this factory produce an object</summary>
    public void Produce()
    {
        // Create the new object from the prefab.
        GameObject newInstance = Instantiate(toProduce, transform.position, Quaternion.identity);

        // Apply the intial velocity to this object.
        newInstance.GetComponent<Rigidbody>().AddForce(spawnVelocity, ForceMode.Impulse);
    }
}

//[CustomEditor(typeof(ObjFactory))]
//public class ObjFactoryEditor : Editor
//{
//    bool show = true;

//    public override void OnInspectorGUI()
//    {
//        show = EditorGUILayout.Foldout(show, "Hello");
//        if (show)
//        {
//            EditorGUILayout.IntField(2);
//        }
//        else
//        {

//        }
//    }
//}

