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
        GameStateUpdate(GameState.MainMenu);
    }
    public void GameStateUpdate(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.MainMenu:
                break;
            case GameState.PlayGame:
                break;
            case GameState.Lose:
                break;
            case GameState.Win:
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
