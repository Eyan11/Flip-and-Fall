using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HubUI : MonoBehaviour
{
    [Header ("References")]
    private GameManager gameManagerScript;
    [SerializeField] private TextMeshProUGUI coinTextLvl1;
    [SerializeField] private TextMeshProUGUI scoreTextLvl1;
    [SerializeField] private TextMeshProUGUI coinTextLvl2;
    [SerializeField] private TextMeshProUGUI scoreTextLvl2;

    //called every time hub scene is loaded
    private void Start() {
        //reference to Game Manager script
        gameManagerScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();

        //update best coins on each level
        coinTextLvl1.text = "" + gameManagerScript.GetBestCoinCountLevel1();
        coinTextLvl2.text = "" + gameManagerScript.GetBestCoinCountLevel2();

        //update best scores on each level
        scoreTextLvl1.text = "" + gameManagerScript.GetBestScoreLevel1();
        scoreTextLvl2.text = "" + gameManagerScript.GetBestScoreLevel2();
    }



}
