using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class OOBCollision : MonoBehaviour
{

    private enum PlayerInteractionType
    {
        none, toNearest
    }

    [SerializeField]
    private PlayerInteractionType playerInteraction;

    private WorldParser world;

    private void OnCollisionEnter(Collision collision)
    {
        // Is the colliding object a force applicable object?
        if (collision.gameObject.GetComponent<KineticProperty>())
        {
            // Destroy the colliding object.
            Destroy(collision.gameObject);
        }
        else
        {
            collision.gameObject.transform.position = world.GetCheckpoint(0).transform.position;
        }
        
    }

    // Use this for initialization
    void Start () {
        world = FindObjectOfType<WorldParser>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

[CustomEditor(typeof(OOBCollision))]
public class OOBCollisionEditor : Editor
{
    private enum PlayerEffectMode
    {
        toLevelOrigin, toLastCheckpoint, toNearestCheckpoint, toCheckpointID
    }


    bool showPlayerInteraction = true;
    int relevantCheckPoint = 0;

    PlayerEffectMode effectMode = PlayerEffectMode.toLastCheckpoint;

    public override void OnInspectorGUI()
    {
        showPlayerInteraction = EditorGUILayout.Toggle("Effects Player", showPlayerInteraction);

        if (showPlayerInteraction)
        {
            effectMode = (PlayerEffectMode)EditorGUILayout.EnumPopup("  Sends player", effectMode);
            switch (effectMode)
            {
                case PlayerEffectMode.toLastCheckpoint:

                    break;
                case PlayerEffectMode.toLevelOrigin:

                    break;
                case PlayerEffectMode.toNearestCheckpoint:

                    break;
                case PlayerEffectMode.toCheckpointID:
                    relevantCheckPoint = Mathf.Abs(EditorGUILayout.IntField("       ID", relevantCheckPoint));
                    break;
            }
        }
    }
}
