using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "GameStateManager", menuName = "ScriptableObjects/GameStateManager", order = 2)]
public class GameStateManager : ScriptableObject
{
    private GameState currentGameState;
    private GameState lastGameState;

    

    public void ChangeGameState(GameState newState)
    {
        currentGameState.Exit();
        lastGameState = currentGameState;
        currentGameState = newState;
        currentGameState.Enter();
    }
}
