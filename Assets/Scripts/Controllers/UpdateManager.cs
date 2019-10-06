using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    [SerializeField]
    PlayerController player;
    static PlayerController playerInstance;
    public static PlayerController Player { get { return playerInstance; } }

    [SerializeField]
    GameStateManager gameStateManager;

    void Start()
    {
        playerInstance = player;
        gameStateManager.ChangeGameState(GameStatesEnum.GamePlayState);
    }

    private void Update()
    {
        gameStateManager.UpdateState();
    }

    private void FixedUpdate()
    {
        gameStateManager.FixedUpdateState();
    }
}
