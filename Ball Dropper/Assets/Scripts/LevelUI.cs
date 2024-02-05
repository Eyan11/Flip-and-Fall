using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private TextMeshProUGUI deathText;
    [SerializeField] private Image skullImage;
    [SerializeField] private Image crownImage;
    [SerializeField] private PlayerState playerStateScript;

    //toggle image of crown and skull
    private GameManager gameManagerScript;

    //get reference to Manager Script
    private void Start() {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void Update() {
        //display coin and score
        coinText.text = "" + gameManagerScript.GetCoins();
        scoreText.text = "" + gameManagerScript.GetScore();

        //player won
        if(playerStateScript.hasWon == true) {
            winText.gameObject.SetActive(true);
            deathText.gameObject.SetActive(false);
            skullImage.gameObject.SetActive(false);
            crownImage.gameObject.SetActive(true);

            string sceneName = SceneManager.GetActiveScene().name;
            if(sceneName == "Level1")
                gameManagerScript.WonLevel1();
            else if(sceneName == "Level2")
                gameManagerScript.WonLevel2();
        }

        //player died
        else if(playerStateScript.playerAlive == false) {
            winText.gameObject.SetActive(false);
            deathText.gameObject.SetActive(true);
            skullImage.gameObject.SetActive(true);
            crownImage.gameObject.SetActive(false);
        }
    }


}
