using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    private GameManager gameManagerScript;
    private AudioManager audioScript;

    //get reference to Manager Script
    private void Start() {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        audioScript = GameObject.Find("Game Manager").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other) {

        //if colliding with player, collect coin
        if(other.gameObject.tag == "Player") {

            gameManagerScript.AddCoin();
            audioScript.PlayCoinSound();
            Destroy(gameObject);
        }
    }

}
