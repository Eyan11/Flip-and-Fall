using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Transform focusObject;
    private Vector3 offset;
    // Calculates initial offset the camera has
    private void Start()
    {
        offset = focusObject.position - transform.position;
    }

    // Translates camera movement to be offset from focusObject; no camera rotation
    private void Update()
    {
        transform.position = focusObject.position - offset;
    }
}
