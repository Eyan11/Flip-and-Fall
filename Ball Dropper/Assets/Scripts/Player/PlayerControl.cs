using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed = 3.0f;
    private Rigidbody body;
    // Retrieves Rigidbody from player
    private void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
    }

    // Applies force to the player
    private void Update()
    {
        Vector3 currentVelocity = Vector3.zero;
        currentVelocity.x = Input.GetAxis("Horizontal");
        currentVelocity.z = Input.GetAxis("Vertical");
        currentVelocity *= speed;

        body.AddForce(currentVelocity, ForceMode.Force);
    }
}
