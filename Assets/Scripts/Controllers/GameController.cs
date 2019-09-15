using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //this controller is persistent across the whole game
    private LevelController levelController;

    private GameState currentGameState;
    private GameState lastGameState;

    public void ChangeGameState(GameState newState)
    {
        currentGameState.Exit();
        lastGameState = currentGameState;
        currentGameState = newState;
        currentGameState.Enter();
    }

    private void Update()
    {
        currentGameState.UpdateState();
    }

    private void FixedUpdate()
    {
        currentGameState.FixedUpdateState();
    }
}
