using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private GameManager gameManager;
    public bool playerAlive = true; // Life (true) or death (false)
    private Rigidbody body;
    private Scene currentScene;
    
    // Retrieves GameManager and Rigidbody
    private void Start() {
        gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        body = gameObject.GetComponent<Rigidbody>();
        currentScene = SceneManager.GetActiveScene();
    }
    
    // Checks objects that collide with player; any with "Obstacle" tag triggers death
    private void OnCollisionEnter(Collision collision) {
        GameObject obj = collision.gameObject;

        if (obj.tag == "Obstacle") {
            Debug.Log("Dead!");
            playerAlive = false;
            body.isKinematic = true;

            gameManager.CompletedDrop();
        }
    }

    // Restarts the level if the player is dead
    private void Update() {
        if (playerAlive == true) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Restarting!");
            SceneManager.LoadScene(currentScene.name);
        }
    }
}
