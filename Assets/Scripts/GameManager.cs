using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
    public static GameManager instance;
    int score = 0;
    int lives = 3;
    bool gameOver = false;
    public Text scoreText;
    public GameObject livesHolder;
    public GameObject gameOverPanel;
    private void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Incrementer()
    {
        if (!gameOver)
        {
            score++;
            scoreText.text = score.ToString();
            // print(score);
        }


    }
    public void DecreaseLife()
    {
        if (lives > 0)
        {
            lives--;
            print(lives);
            livesHolder.transform.GetChild(lives).gameObject.SetActive(false);
        }
        if (lives <= 0)
        {
            gameOver = true;
            GameOver();
        }
    }
    public void GameOver()
    {
        CandySpawner.instance.StopSpawningCandies();
        GameObject.Find("Player").GetComponent<PlayerController>().canMove = false;
        gameOverPanel.SetActive(true);
        print("Game over");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }


}
