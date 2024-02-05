using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float playerStartHeight = 0f;
    private Transform playerTran = null;
    //level stat trackers
    private int currentCoins = 0;
    private int currentScore = 0;

    private int bestCoinCountLvl1 = 0;
    private int bestCoinCountLvl2 = 0;

    private int bestScoreLvl1 = 0;
    private int bestScoreLvl2 = 0;

    private bool hasWonLvl1 = false;
    private bool hasWonLvl2 = false;

    //keeps Game Manager object active throughout every scene and deletes duplicates
    private void Awake() {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Manager");

        if(objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    //check if best scores need to be updated
    public void CompletedDrop() {

        string sceneName = SceneManager.GetActiveScene().name;

        //check for new best coin count level 1
        if((sceneName == "Level1") && (GetCoins() > GetBestCoinCountLevel1())) {
            SetBestCoinCountLevel1(GetCoins());
            Debug.Log("New Best Coin Count Level 1: " + GetBestCoinCountLevel1());
        }

        //check for new best coin count level 2
        if((sceneName == "Level2") && (GetCoins() > GetBestCoinCountLevel2())) {
            SetBestCoinCountLevel2(GetCoins());
            Debug.Log("New Best Coin Count Level 2: " + GetBestCoinCountLevel2());
        }

        //check for new best score level 1
        if((sceneName == "Level1") && (GetScore() > GetBestScoreLevel1())) {
            SetBestScoreLevel1(GetScore());
            Debug.Log("New Best Score Level 1: " + GetBestScoreLevel1());
        }

        //check for new best score level 2
        if((sceneName == "Level2") && (GetScore() > GetBestScoreLevel2())) {
            SetBestScoreLevel2(GetScore());
            Debug.Log("New Best Score Level 2: " + GetBestScoreLevel2());
        }

        //remove player tran so it can be added back after respawn (since player isn't persistent)
        playerTran = null;
        //set current coins and scores to 0 for new drop attempt
        ResetDropStats();
    }

    //calculate player score
    private void Update() {
        //don't calculate score in hub
        string sceneName = SceneManager.GetActiveScene().name;
        if(sceneName == "HubScene")
            return;
        
        //grab reference to player transform every time player respawns
        if(playerTran == null) {
            playerTran = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            playerStartHeight = playerTran.position.y;
        }

        if(playerTran.position.y < (playerStartHeight - 1)) {
            SetScore(Mathf.FloorToInt(Mathf.Abs(playerTran.position.y - (playerStartHeight - 1))));
        }
    }

    //resets coins and scores of lvl 1 and 2, called when drop is completed
    public void ResetDropStats() {
        currentCoins = 0;
        currentScore = 0;
    }

    // ------------ Win Getter and Setters ---------------

    //called when player wins level 1
    public void WonLevel1() {
        hasWonLvl1 = true;
    }

    //called when player wins level 2
    public void WonLevel2() {
        hasWonLvl2 = true;
    }

    //checks if player won level 1
    public bool GetLevel1WinStatus() {
        return hasWonLvl1;
    }

    //checks if player won level 2
    public bool GetLevel2WinStatus() {
        return hasWonLvl2;
    }

    // -------- Coin and Score Getter and Setters -----------

    // -------- Coins -----------

    //add one coin to lvl 1
    public void AddCoin() {
        currentCoins++;
    }

    //returns level 1 count count
    public int GetCoins() {
        return currentCoins;
    }

    // -------- Score -----------

    //sets current level score
    public void SetScore(int score) {
        currentScore = score;
    }


    //returns current level score
    public int GetScore() {
        return currentScore;
    }

    // -------- Best Coins -----------

    //sets best coin count in level 1
    public void SetBestCoinCountLevel1(int coins) {
        bestCoinCountLvl1 = coins;
    }

    //sets best coin count in level 2
    public void SetBestCoinCountLevel2(int coins) {
        bestCoinCountLvl2 = coins;
    }

    //returns most coins grabbed in level 1
    public int GetBestCoinCountLevel1() {
        return bestCoinCountLvl1;
    }

    //returns most coins grabbed in level 2
    public int GetBestCoinCountLevel2() {
        return bestCoinCountLvl2;
    }

    // -------- Best Score -----------

    //sets best score in level 1
    public void SetBestScoreLevel1(int score) {
        bestScoreLvl1 = score;
    }

    //sets best score in level 2
    public void SetBestScoreLevel2(int score) {
        bestScoreLvl2 = score;
    }

    //returns best score in level 1
    public int GetBestScoreLevel1() {
        return bestScoreLvl1;
    }

    //returns best score in level 2
    public int GetBestScoreLevel2() {
        return bestScoreLvl2;
    }

}
