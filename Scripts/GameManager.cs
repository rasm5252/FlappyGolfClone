using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }
    
    public bool gameOver = false;
    [SerializeField] private GameObject gameOverUI;

    private void Start() {
        EventManager.Instance.onGameOver += GameOver;
        EventManager.Instance.onLevelComplete += LevelComplete;
    }

    private void GameOver() {
        gameOver = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }

    private void LevelComplete() {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % (SceneManager.sceneCount + 1));
    }

    public void Restart() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
