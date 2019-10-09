using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    [SerializeField]
    GameStateManager gameStateManager;

    void Start()
    {
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
