using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private GameManager gameManager;
    private AudioManager audioScript;
    
    private void Start() {
        gameManager = GameObject.FindWithTag("Manager").GetComponent<GameManager>();
        audioScript = GameObject.FindWithTag("Manager").GetComponent<AudioManager>();

        // Turns trigger invisible
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
    
    // Only triggers if the player touched it; disables death
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag != "Player") {
            return;
        }

        GameObject player = other.gameObject;
        PlayerState playerState = player.GetComponent<PlayerState>();

        // Can't retrigger the win trigger
        if (playerState.hasWon == true) {
            return;
        }

        Debug.Log("Victory!");
        audioScript.PlayWinSound();
        playerState.hasWon = true;
    }
}
