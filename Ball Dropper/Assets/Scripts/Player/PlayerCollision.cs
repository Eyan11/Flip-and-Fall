using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;
    
    // Retrieves GameManager
    private void Start() {
        gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
    }
    
    // Checks objects that collide with player; any with "Obstacle" tag triggers death
    private void OnCollisionEnter(Collision collision) {
        GameObject obj = collision.gameObject;

        if (obj.tag == "Obstacle") {
            Debug.Log("Dead!");

            gameManager.CompletedDrop();

            // TODO: figure out what to do next--reload level?
        }
    }
}
