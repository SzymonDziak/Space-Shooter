using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text restartText;
    [SerializeField]
    private Text gameOverText;

    private bool gameOver;
    private bool restart;

    [SerializeField]
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves ());
    }

    // Update is called once per frame
    private void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds(startWait);
        while (!gameOver)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 0.0f, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            if (gameOver)
            {
                yield return new WaitForSeconds(3);
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "" + score;
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }
}

