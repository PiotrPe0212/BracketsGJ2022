using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 initPos = new Vector3(0, 0, 0);
    public static int InitMentalHealth = 10 ;

    private bool gameStarted = false;
    public int ActualMentalHealth;
    public int damageValue;

    private void Awake()
    {
        GameManager.OnGameStateChange += OnStateChangeMenuChange;
        PlayerController.DamageAdded += ChangeHealth;
    }
    private void OnDestroy()
    {
        GameManager.OnGameStateChange -= OnStateChangeMenuChange;
        PlayerController.DamageAdded -= ChangeHealth;
    }
   
    private void OnStateChangeMenuChange(GameManager.GameState newState)
    {
       
        if(newState == GameManager.GameState.PlayGame) InitFunction();
      
    }

    private void ChangeHealth()
    {
        ActualMentalHealth -= damageValue;
    }


    void FixedUpdate()
    {
        if (!gameStarted) return;
        if (ActualMentalHealth <= 0) ChangeStateToLose();
        
    }

    private void InitFunction()
    {
        gameStarted = true;
        ActualMentalHealth = InitMentalHealth;
        //Instantiate(player, initPos, Quaternion.identity);

        //move to the parrent gameObject


    }

    private void ChangeStateToLose()
    {
        GameManager.Instance.GameStateUpdate(GameManager.GameState.Lose);
       gameStarted = false;
    }
}
