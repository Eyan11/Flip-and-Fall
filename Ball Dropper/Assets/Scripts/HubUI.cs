using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class HubUI : MonoBehaviour
{
    [Header ("References")]
    private GameManager gameManagerScript;
    [SerializeField] private TextMeshProUGUI coinTextLvl1;
    [SerializeField] private TextMeshProUGUI scoreTextLvl1;
    [SerializeField] private TextMeshProUGUI coinTextLvl2;
    [SerializeField] private TextMeshProUGUI scoreTextLvl2;
    [SerializeField] private Image skullImageLvl1;
    [SerializeField] private Image crownImageLvl1;
    [SerializeField] private Image skullImageLvl2;
    [SerializeField] private Image crownImageLvl2;

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

        if(gameManagerScript.GetLevel1WinStatus()) {
            skullImageLvl1.gameObject.SetActive(false);
            crownImageLvl1.gameObject.SetActive(true);
        }
        else if(gameManagerScript.GetLevel2WinStatus()) {
            skullImageLvl2.gameObject.SetActive(false);
            crownImageLvl2.gameObject.SetActive(true);
        }

    }



}
