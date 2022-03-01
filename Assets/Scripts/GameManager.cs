using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource menuMusic;
    [SerializeField] private AudioSource gameMusic;
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
                menuMusic.Play();
                gameMusic.Stop();
                break;
            case GameState.PlayGame:
                Time.timeScale = 1;
                menuMusic.Stop();
                gameMusic.Play();
                break;
            case GameState.Lose:
                Time.timeScale = 0;
                break;
            case GameState.Win:
                Time.timeScale = 1;
                SceneManager.LoadScene("EndScene Test");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof (newState), newState, null);
        }
        print(newState);
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
