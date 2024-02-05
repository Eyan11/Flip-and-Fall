using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private GameManager gameManager;
    
    private void Start() {
        gameManager = GameObject.FindWithTag("Manager").GetComponent<GameManager>();
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

        playerState.hasWon = true;
    }
}
