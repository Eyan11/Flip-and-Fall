using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPortal : MonoBehaviour
{
    [Header ("Enter 0 if hub portal:")]
    [SerializeField] private int levelOfPortal;


    private void OnTriggerEnter(Collider other) {

        if(other.tag == "Player") {

            if(levelOfPortal == 0)
                SceneManager.LoadScene("HubScene");
            else if(levelOfPortal == 1)
                SceneManager.LoadScene("Level1");
            else if(levelOfPortal == 2)
                SceneManager.LoadScene("Level2");
        }
    }



}
