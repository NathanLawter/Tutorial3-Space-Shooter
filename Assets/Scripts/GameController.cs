using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour { 
    public GameObject[] hazards;
    public Vector3 spawnValue;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text ScoreText;
    public Text RestartText;
    public Text GameOverText;

    private bool gameOver;
    private bool restart;
    private int score;

    void Start ()
    {
        gameOver = false;
        restart = false;
        GameOverText.text = "";
        RestartText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves ());
    }
    void Update()
    {
        if (restart)
        {
            if (Input.GetKey("r"));
            {
                Application.LoadLevel (Application.loadedLevel);
            }
        }
            if (Input.GetKey("escape"))
            {
                Application.Quit();
            }
        }
        IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range (0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                RestartText.text = "Press 'R' to Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
        {
            score += newScoreValue;
            UpdateScore();
        }

    void UpdateScore()
        {
            ScoreText.text = "Score: " + score;
        }
    public void GameOver()
    {
        GameOverText.text = "GAME OVER";
        gameOver = true;
    }
}