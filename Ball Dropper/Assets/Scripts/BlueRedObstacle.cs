using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueRedObstacle : MonoBehaviour
{
    [Header ("Settings")]
    [SerializeField] private bool isBlue;
    private bool blueIsTransparent = true;

    [Header ("References")]
    [SerializeField] private MeshRenderer fillMesh;
    private BoxCollider collider = null;


    //runs when object is spawned in (before Start())
    private void Awake() {
        collider = GetComponent<BoxCollider>();
        
        //start with blue transparent and red visible
        if(isBlue && blueIsTransparent) {
            collider.enabled = false;
            fillMesh.enabled = false;
        }
        //red should already have collider and mesh enabled
    }

    private void Update() {

        //if space is pressed, flip obstacles visibility
        if(Input.GetKeyDown(KeyCode.Space))
            blueIsTransparent = !blueIsTransparent;

        //blue is transparent
        if(isBlue && blueIsTransparent) {
            collider.enabled = false;
            fillMesh.enabled = false;
        }
        //blue is visible
        else if(isBlue && !blueIsTransparent) {
            collider.enabled = true;
            fillMesh.enabled = true;
        }
        //red is transparent
        else if(!isBlue && !blueIsTransparent) {
            collider.enabled = false;
            fillMesh.enabled = false;
        }
        //red is visible
        else if(!isBlue && blueIsTransparent) {
            collider.enabled = true;
            fillMesh.enabled = true;
        }
    }

}
