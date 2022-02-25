using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChange;

        private void Awake()
    {
        Instance = this;
    }


    private void Start()
    {
        GameStateUpdate(State);
    }
    public void GameStateUpdate(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.MainMenu:
                Time.timeScale = 0;
                break;
            case GameState.PlayGame:
                Time.timeScale = 1;
                break;
            case GameState.Lose:
                Time.timeScale = 0;
                break;
            case GameState.Win:
                Time.timeScale = 0;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof (newState), newState, null);
        }

        OnGameStateChange?.Invoke(newState);
    }


    public enum GameState
    {
        MainMenu,
        PlayGame,
        Lose,
        Win
    }

}
