using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{
    private GameManager gameManager;
    private AudioManager audioScript;
    private Rigidbody body;
    private Scene currentScene;
    [HideInInspector] public bool playerAlive = true;
    [HideInInspector] public bool hasWon = false;
    
    // Retrieves GameManager
    private void Start() {
        gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        audioScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<AudioManager>();
        body = gameObject.GetComponent<Rigidbody>();
        currentScene = SceneManager.GetActiveScene();
    }
    
    // Checks objects that collide with player; any with "Obstacle" tag triggers death
    private void OnCollisionEnter(Collision collision) {
        if (playerAlive == false) {
            return;
        }

        GameObject obj = collision.gameObject;

        if (obj.tag != "Obstacle") {
            return;
        }

        if (hasWon == true) {
            return;
        }

        Debug.Log("Dead!");

        // Freezes player, changes their state to "unalive" and updates coin counter
        audioScript.PlayDeathSound();
        body.isKinematic = true;
        playerAlive = false;
    }

    // When dead, allow the player to restart the level on 'R' press down
    private void Update() {
        if (playerAlive == true && hasWon == false) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.R) == false) {
            return;
        }

        Debug.Log("Restarting level!");

        // No other variables in the player need to be changed back
        // The player is not preserved (or shouldn't be)
        audioScript.PlayRespawnSound(); //might need to move to after respawning if sound cuts out
        gameManager.CompletedDrop();
        SceneManager.LoadScene(currentScene.name);
    }
}
