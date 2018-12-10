using System.Collections.Generic;
using UnityEngine;

/// <summary>Class for accessing key items that are currently loaded</summary>
public class WorldParser : MonoBehaviour
{
    // Get references for prefabs.
    [SerializeField]
    private GameObject checkpointPrefab;

    /*
     * Storage for all important objects currently in the scene.
    */

    // All loaded checkpoints, organized by unique ID#.
    private Dictionary<int, Checkpoint> loadedCheckpoints = new Dictionary<int, Checkpoint>();

#if DEBUG
    // All current debug mesh renderers in the scene.
    private List<GameObject> debugObjects = new List<GameObject>();
#endif

    /*
     * Methods for parsing the current scene.
    */

    // Parse the scene when it is loaded.
    private void Start(){ ParseScene(); }

    /// <summary>Updates the currently loaded scene objects</summary>
    public void ParseScene()
    {
        // Clear out all previously loaded objects.
        loadedCheckpoints.Clear();
#if DEBUG
        debugObjects.Clear();
#endif

        // Handle the display of this world logic gameobject.
        HandleChildDebugObjects(gameObject);

        /*
         * Parse all of the checkpoints currently loaded in the scene.
        */

        // Declare a dictionary to store the parsed checkpoints.
        Dictionary<int, GameObject> checkpoints = new Dictionary<int, GameObject>();

        // Cycle through all objects tagged as checkpoints.
        foreach (GameObject checkpoint in GameObject.FindGameObjectsWithTag("Checkpoint"))
        {
            // Get the checkpoint script off of this object.
            Checkpoint script = checkpoint.GetComponent<Checkpoint>();

            // Does this script not exist?
            if (script == null)
            {
#if DEBUG
                // Print a warning out to the console.
                Debug.LogWarning("\"" + checkpoint.name + "\" is tagged as checkpoint but contains no checkpoint script.");
#endif
            }
            else
            {
                // Does this checkpoint have the same ID as another?
                if (checkpoints.ContainsKey(script.pointNumber))
                {
#if DEBUG           
                    // Print a warning out to the console.
                    Debug.LogWarning("Gameobject \"" + checkpoint + "\" was denied a checkpoint because ID#" +
                        script.pointNumber + " already belongs to \"" + checkpoints[script.pointNumber].name + "\"." +
                        " Considering deleting one of the checkpoints or changing an identity.");
#endif
                }
                else
                {
                    // Add this checkpoint to the dictionary.
                    checkpoints.Add(script.pointNumber, checkpoint);
                }
            }
        }
        // All checkpoints parsed.

        // Is there no checkpoint for the level origin?
        if (!checkpoints.ContainsKey(0))
        {
#if DEBUG
            Debug.LogWarning("There is no checkpoint in the scene with the ID#0. Please create this checkpoint." +
                " ID#0 has been created by default at the scene origin.");
#endif
            // Create the level origin checkpoint at the scene origin.
            GameObject originCP = Instantiate(checkpointPrefab, Vector3.zero, Quaternion.identity);
            checkpoints.Add(0, originCP);
        }

        // Transfer the loaded checkpoints into the accesible dictionary.
        foreach (KeyValuePair<int, GameObject> checkpoint in checkpoints)
        {
            loadedCheckpoints.Add(checkpoint.Key, checkpoint.Value.GetComponent<Checkpoint>());

            // Based on the build, handle the visual debug children.
            HandleChildDebugObjects(checkpoint.Value);
        }
    }

    // Handles debug children based on the build configuration.
    private void HandleChildDebugObjects(GameObject parent)
    {
#if DEBUG
        // Add the children of this checkpoint to the debug objects.
        foreach (Transform child in parent.transform)
        {
            debugObjects.Add(child.gameObject);
        }
#else
        // Destroy the children under this checkpoint(they are debug only).
        foreach (Transform child in checkpoint.Value.transform)
        {
            Destroy(child.gameObject);
        }
#endif
    }

    /****************************************
     * 
     * Methods that other objects can access during runtime. 
     * 
    ****************************************/

    /*
     * Methods related to checkpoints. 
    */

    /// <summary>Get a currently loaded checkpoint</summary>
    /// <param name="checkpointID">The ID# of the checkpoint to get</param>
    /// <returns>The checkpoint associated with this number, null if none exists</returns>
    public Checkpoint GetCheckpoint(int checkpointID)
    {
        // Does the requested checkpoint not exist?
        if (!loadedCheckpoints.ContainsKey(checkpointID))
        {
            // Return null if this checkpoint does not exist.
            return null;
        }
        else
        {
            // Else return the checkpoint with this ID.
            return loadedCheckpoints[checkpointID];
        }
    }

    /*
     * Debug only methods. 
    */

#if DEBUG
    /// <summary>Shows or hides debug objects during runtime</summary>
    /// <param name="isEnabled">If true, objects will be shown</param>
    public void SetDebugVision(bool isEnabled)
    {
        // Enable or disable all debug only objects.
        foreach(GameObject debugObject in debugObjects)
        {
            debugObject.SetActive(isEnabled);
        }
    }
#endif
}