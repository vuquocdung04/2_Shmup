using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int score = 0;
    public TextMeshPro scoreText;
    public TextMeshPro levelText;
    public GameObject gameOver;
    public GameObject levelNext;

    //Camera
    public Camera mainCamera;
    public Vector3 originalPosition;
    public float shakeDuration = 0.3f;  
    public float shakeMagnitude = 0.1f;



    public PlayerController playerController;
    public int levelGame = 1;
    private void Start()
    {
        levelGame = PlayerPrefs.GetInt("Level", levelGame);
        levelText.text = "Level: " + levelGame;
        scoreText.text = "Score: " + score;
        gameOver.SetActive(false);
        levelNext.SetActive(false);

        originalPosition = mainCamera.transform.position;
    }
    private void Update()
    {
        if (playerController.gameOver == true)
        {
            this.gameOver.SetActive(true);
        }

        if (levelNext.activeInHierarchy)
        {
            playerController.enabled = false;
        }
    }

    public void ShakeCamera()
    {
        StartCoroutine(ShakeCoroutine());
    }
    private IEnumerator ShakeCoroutine()
    {
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;
            mainCamera.transform.position = new Vector3(originalPosition.x + x, originalPosition.y + y, -10);

            elapsed += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.position = originalPosition;  
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void NextLevel()
    {
        levelGame++;
        PlayerPrefs.SetInt("Level", levelGame);
        Debug.Log("Level game: " + levelGame);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
