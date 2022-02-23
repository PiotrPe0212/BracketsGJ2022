using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private PlayerController Player;
    [SerializeField] private GameObject PlayerBar;

    public float InitialPlayerHealt;
    public int healthScale;
    private float actualPlayerHealth;
    private Slider sliderPlayer;
    private float healthLoose = 1;
    private void Awake()
    {
        GameManager.OnGameStateChange += OnStateChangeMenuChange;
        PlayerController.DamageAdded += PlayerHealthLoos;
        sliderPlayer = gameObject.GetComponent < Slider>();
      
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChange -= OnStateChangeMenuChange;
        PlayerController.DamageAdded -= PlayerHealthLoos;

    }

    private void OnStateChangeMenuChange(GameManager.GameState newState)
    {
        if (newState == GameManager.GameState.PlayGame)
        {
            InitFunction();
        }
    }

  

    void PlayerHealthLoos()
    {
        actualPlayerHealth -= healthLoose;
        sliderPlayer.value = actualPlayerHealth/healthScale;

    }
 

    void InitFunction()
    {
        actualPlayerHealth = InitialPlayerHealt;
        healthScale = GameplayManager.InitMentalHealth;
        sliderPlayer.value = actualPlayerHealth / healthScale;

    }
}
