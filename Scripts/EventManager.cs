using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }
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

    public event Action onGameOver;
    public void GameOver() {
        /*if (onGameOver != null) {
            onGameOver();
        }*/
        onGameOver?.Invoke();
    }

    public event Action onLevelComplete;
    public void LevelComplete() {
        onLevelComplete?.Invoke();
    }

}