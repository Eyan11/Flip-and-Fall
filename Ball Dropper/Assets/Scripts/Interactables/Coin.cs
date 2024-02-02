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

        //if colliding with player, add to coin counter and despawn
        if(other.gameObject.tag == "Player") {

            //check which level the coin is in
            string sceneName = SceneManager.GetActiveScene().name;

            //TODO: adjust sceneName check depending on actual name of scene
            //add coin to corresponding level
            if(sceneName == "Level1") {
                Debug.Log("Level 1 Coin Collected!");
                gameManagerScript.AddCoinLevel1();
            }
            else if(sceneName == "Level2") {
                Debug.Log("Level 2 Coin Collected!");
                gameManagerScript.AddCoinLevel2();
            }
            
            //despawn coin
            Destroy(gameObject);
        }
    }

}
