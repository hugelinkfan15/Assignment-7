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
    public SpawnManager sM;
    public bool gameOver;
    public static bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.0f;
        isPaused = true;
        waveText.text = "Current wave: " + sM.waveNumber;
    }

    // Update is called once per frame
    void Update()
    {
        if (sM.waveNumber > 10) { gameOver = true; }
        if (gameOver)
        {
            Time.timeScale = 0.0f;
            startText.text = (sM.waveNumber > 10) ? "You Win!\nPress R to restart!" : "You Lose!\nPress R to restart!";
            startText.gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if (Time.timeScale == 0.0f && Input.GetKeyDown(KeyCode.Space))
        {
           startText.gameObject.SetActive(false);
            Time.timeScale = 1.0f;
            isPaused = false;
        }

        waveText.text = "Current wave: " + sM.waveNumber;
    }
}
