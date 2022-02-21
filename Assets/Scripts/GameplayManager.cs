using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 initPos = new Vector3(0, 0, 0);
    [SerializeField] private int InitMentalHealth = 10;
    private bool gameStarted = false;
    public int ActualMentalHealth;


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
        if(newState == GameManager.GameState.PlayGame)
        {
            InitFunction();
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void InitFunction()
    {
        gameStarted = true;
        ActualMentalHealth = InitMentalHealth;
        Instantiate(player, initPos, Quaternion.identity);

        //move to the parrent gameObject


    }
}
