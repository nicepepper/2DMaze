using System.Collections;
using Data;
using Game;
using Map;
using UnityEngine;

public class GameLogicController : MonoBehaviour 
{
    private void Awake() 
    {
        GameEvent.OnReady += OnGameReady;
    }

    private void OnDestroy() {
        GameEvent.OnReady -= OnGameReady;
    }

    private void OnGameReady() 
    {
       GameController.StartGame();
    }
    
    private void CheckGameOver() 
    {
        GameController.StopGame();
    }
}