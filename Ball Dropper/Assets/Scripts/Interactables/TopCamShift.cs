using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopCamShift : MonoBehaviour
{
    private Vector3 topDownOffset = new Vector3(0.0f, -5.0f, 0.0f);
    private Vector3 topDownRotation = new Vector3(90f, 0f, 0f);
    private GameObject playerCamObj;
    private PlayerCam cam;

    // Retrieves player cam object and turns trigger invisible
    private void Start() {
        playerCamObj = GameObject.FindGameObjectWithTag("MainCamera");
        cam = playerCamObj.GetComponent<PlayerCam>();

        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    // Shifts the cam into a top-down cam if triggered
    private void OnTriggerEnter(Collider other) {
        GameObject obj = other.gameObject;

        if (obj.tag != "Player") {
            return;
        }

        playerCamObj.transform.eulerAngles = topDownRotation;
        cam.offset = topDownOffset;
    }
}
