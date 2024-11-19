/*
* Kayden Miller
* Assignment 7
* Managers various Gameobjects withint the scene
*/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI startText;
    public TextMeshProUGUI waveText;
    public SpawnManagerX sM;
    public static bool gameOver;
    public static bool isPaused;
    public static int enemiesLost = -1;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.0f;
        isPaused = true;
        waveText.text = "Current wave: " + sM.waveCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (sM.waveCount > 10) { gameOver = true; }
        if (gameOver)
        {
            Time.timeScale = 0.0f;
            startText.text = (sM.waveCount > 10) ? "You Win!\nPress R to restart!" : "You Lose!\nPress R to restart!";
            startText.gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.R))
            {
                gameOver = false;
                enemiesLost = -1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if (Time.timeScale == 0.0f && Input.GetKeyDown(KeyCode.Space))
        {
           startText.gameObject.SetActive(false);
            Time.timeScale = 1.0f;
            isPaused = false;
        }

        waveText.text = "Current wave: " + (sM.waveCount-1);
    }
}
