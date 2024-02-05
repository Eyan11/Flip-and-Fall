using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPortal : MonoBehaviour
{
    [Header ("Enter 0 if hub portal:")]
    [SerializeField] private int levelOfPortal;

    private AudioManager audioScript;

    //get reference to Manager Script
    private void Start() {
        audioScript = GameObject.Find("Game Manager").GetComponent<AudioManager>();
    }


    private void OnTriggerEnter(Collider other) {

        if(other.tag == "Player") {
            //portal sound
            audioScript.PlayPortalSound();

            //load correcrt scene
            if(levelOfPortal == 0)
                SceneManager.LoadScene("HubScene");
            else if(levelOfPortal == 1)
                SceneManager.LoadScene("Level1");
            else if(levelOfPortal == 2)
                SceneManager.LoadScene("Level2");

        }
    }



}
