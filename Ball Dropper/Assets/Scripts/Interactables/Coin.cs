using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    private GameManager gameManagerScript;

    //get reference to Manager Script
    private void Start() {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other) {

        //if colliding with player
        if(other.gameObject.tag == "Player") {
            //add coin to currentCoins in level
            gameManagerScript.AddCoin();
            //despawn coin
            Destroy(gameObject);
        }
    }

}
