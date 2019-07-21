using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues; // for astreoids
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
    [SerializeField]
    private Text selectedMissile;

    private bool gameOver;
    private bool restart;

    [SerializeField]
    private int score;

    [SerializeField]
    private float adjustment; // Skybox rotation

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
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * adjustment); // rotates the SKYBOX to bring the game to life.
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(1);
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
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 0.0f, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
            yield return new WaitForSeconds(waveWait);
        }
        if (gameOver)
        {
            restartText.text = "Press 'R' for Restart";
            restart = true;
        }
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "" + score.ToString().PadLeft(6,'0');
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }
}

