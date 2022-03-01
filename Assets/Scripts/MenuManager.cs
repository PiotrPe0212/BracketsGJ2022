using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _menuPanel, _losePanel;



    private void Awake()
    {
        GameManager.OnGameStateChange += OnStateChangeMenuChange;
    }
    private void OnDestroy()
    {
        GameManager.OnGameStateChange -= OnStateChangeMenuChange;
    }
    // Start is called before the first frame update
    private void OnStateChangeMenuChange(GameManager.GameState newState)
    {
        _menuPanel.SetActive(newState == GameManager.GameState.MainMenu);
        _losePanel.SetActive(newState == GameManager.GameState.Lose);
      

    }

    public void StartButtonPressed()
    {
        GameManager.Instance.GameStateUpdate(GameManager.GameState.PlayGame);
    }

    public void MainMenuButtonPressed()
    {
        GameManager.Instance.GameStateUpdate(GameManager.GameState.MainMenu);
    }


    public void ExitButtonPressed()
    {
        Application.Quit();
    }
 

   
}
