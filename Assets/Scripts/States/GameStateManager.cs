using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "GameStateManager", menuName = "ScriptableObjects/GameStateManager", order = 2)]
public class GameStateManager : ScriptableObject
{
    private Dictionary<GameStatesEnum, GameState> gameStateMap;

    [SerializeField]
    private GamePlayState gamePlayState;
    [SerializeField]
    private PlayerDeathState playerDeathState;

    private GameState currentGameState;
    private GameState lastGameState;

    private void OnEnable()
    {
        gameStateMap = new Dictionary<GameStatesEnum, GameState>();
        gameStateMap.Add(GameStatesEnum.GamePlayState, gamePlayState);
        gameStateMap.Add(GameStatesEnum.PlayerDeathState, playerDeathState);
    }

    public void ChangeGameState(GameStatesEnum newStateEnum)
    {
        GameState newState = gameStateMap[newStateEnum];

        if(currentGameState != null)
            currentGameState.Exit();
        lastGameState = currentGameState;
        currentGameState = newState;
        currentGameState.Enter();
    }

    public void UpdateState()
    {
        currentGameState.UpdateState();
    }

    public void FixedUpdateState()
    {
        currentGameState.FixedUpdateState();
    }

    public void RestartGameStateReferences()
    {
        foreach(KeyValuePair<GameStatesEnum, GameState> entry in gameStateMap)
        {
            entry.Value.ClearReferences();
        }
    }
}
public enum GameStatesEnum
{
    GamePlayState,
    PauseState,
    PlayerDeathState
}
