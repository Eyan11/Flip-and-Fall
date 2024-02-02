using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //level stat trackers
    private int coinCountLvl1 = 0;
    private int scoreLvl1 = 0;
    private int coinCountLvl2 = 0;
    private int scoreLvl2 = 0;

    private int bestCoinCountLvl1 = 0;
    private int bestCoinCountLvl2 = 0;

    private int bestScoreLvl1 = 0;
    private int bestScoreLvl2 = 0;

    private void Update() {

        //TESTING: switching scenes
        /*
        if(Input.GetKeyDown(KeyCode.H))
            SceneManager.LoadScene("HubScene");
        else if(Input.GetKeyDown(KeyCode.O))
            SceneManager.LoadScene("Level1");
        else if(Input.GetKeyDown(KeyCode.T))
            SceneManager.LoadScene("Level2");
        */
    }

    //keeps Game Manager object active throughout every scene and deletes duplicates
    private void Awake() {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Manager");

        if(objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    //check if best scores need to be updated
    public void CompletedDrop() {

        //check for new best coin count level 1
        if(GetCoinsLevel1() > GetBestCoinCountLevel1()) {
            SetBestCoinCountLevel1(GetCoinsLevel1());
            Debug.Log("New Best Coin Count Level 1: " + GetBestCoinCountLevel1());
        }

        //check for new best coin count level 2
        if(GetCoinsLevel2() > GetBestCoinCountLevel2()) {
            SetBestCoinCountLevel2(GetCoinsLevel2());
            Debug.Log("New Best Coin Count Level 2: " + GetBestCoinCountLevel2());
        }

        //check for new best score level 1
        if(GetScoreLevel1() > GetBestScoreLevel1()) {
            SetBestScoreLevel1(GetScoreLevel1());
            Debug.Log("New Best Score Level 1: " + GetBestScoreLevel1());
        }

        //check for new best score level 2
        if(GetScoreLevel2() > GetBestScoreLevel2()) {
            SetBestScoreLevel2(GetScoreLevel2());
            Debug.Log("New Best Score Level 2: " + GetBestScoreLevel2());
        }

        //set current coins and scores to 0 for new drop attempt
        ResetDropStats();
    }



    // -------- Coin and Score Getter and Setters -----------

    //resets coins and scores of lvl 1 and 2, called when drop is completed
    public void ResetDropStats() {
        coinCountLvl1 = 0;
        coinCountLvl2 = 0;
        scoreLvl1 = 0;
        scoreLvl2 = 0;
    }

    // -------- Coins -----------

    //add one coin to lvl 1
    public void AddCoinLevel1() {
        coinCountLvl1++;
    }

    //add one coin to lvl 2
    public void AddCoinLevel2() {
        coinCountLvl2++;
    }

    //returns level 1 count count
    public int GetCoinsLevel1() {
        return coinCountLvl1;
    }

    //returns level 2 count count
    public int GetCoinsLevel2() {
        return coinCountLvl2;
    }

    // -------- Score -----------

    //sets score of level 1
    public void SetScoreLevel1(int score) {
        scoreLvl1 = score;
    }

    //sets score of level 2
    public void SetScoreLevel2(int score) {
        scoreLvl2 = score;
    }

    //returns level 1 score
    public int GetScoreLevel1() {
        return scoreLvl1;
    }

    //returns level 2 score
    public int GetScoreLevel2() {
        return scoreLvl2;
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
