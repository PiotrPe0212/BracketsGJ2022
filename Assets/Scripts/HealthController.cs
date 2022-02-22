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
    private float healthLoose;
    private void Awake()
    {
        PlayerController.DamageAdded += PlayerHealthLoos;
      
    }

    private void OnDestroy()
    {
        PlayerController.DamageAdded -= PlayerHealthLoos;

    }
    
    void Start()
    {
        resetParameters();

    }

    void PlayerHealthLoos()
    {
        actualPlayerHealth -= healthLoose;
        sliderPlayer.value = actualPlayerHealth/healthScale;

    }
 

    void resetParameters()
    {
        actualPlayerHealth = InitialPlayerHealt;
        healthScale = GameplayManager.InitMentalHealth;
    }
}
