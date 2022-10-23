using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;
    [SerializeField] private PlayerTurn playerOne;
    [SerializeField] private PlayerTurn playerTwo;
    [SerializeField] private float timeBetweenTurns;
    [SerializeField] private float turnDuration;
    
    public CinemachineFreeLook[] cameras;
    private int currentPlayerIndex;
    private bool waitingForNextTurn;
    private float turnDelay;
    private float currentTurnTime;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // initializing the current player index as 1
            currentPlayerIndex = 1;
            playerOne.SetPlayerTurn(1);
            playerTwo.SetPlayerTurn(2);
        }
    }

    private void Update()
    {
        currentTurnTime += Time.deltaTime;

        if (currentTurnTime >= turnDuration)
        {
            ChangeTurn();
            //currentTurnTime = 0;
        }
        
        if (currentPlayerIndex == 1)
        {
            cameras[1].gameObject.SetActive(false);
            cameras[0].gameObject.SetActive(true);
        }
        else
        {
            cameras[0].gameObject.SetActive(false);
            cameras[1].gameObject.SetActive(true);
        }
        
        if (waitingForNextTurn)
        {
            turnDelay += Time.deltaTime;
            if (turnDelay >= timeBetweenTurns)
            {
                turnDelay = 0;
                waitingForNextTurn = false;
                ChangeTurn();
            }
        }
    }

    public bool IsItPlayerTurn(int index)
    {
        if (waitingForNextTurn)
        {
            return false;
        }
        // identifying the current player
        return index == currentPlayerIndex;
    }

    public static TurnManager GetInstance()
    {
        return instance;
    }

    public void TriggerChangeTurn()
    {
        waitingForNextTurn = true;
    }

    public void ChangeTurn()
    {
        // changing the active player
        if (currentPlayerIndex == 1)
        {
            currentPlayerIndex = 2;
        }
        else if (currentPlayerIndex == 2)
        {
            currentPlayerIndex = 1;
        }
        
        currentTurnTime = 0;
    }
}
