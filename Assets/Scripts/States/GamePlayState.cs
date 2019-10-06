using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GamePlayState", menuName = "ScriptableObjects/GameStates/GamePlayState", order = 1)]
public class GamePlayState : GameState
{
    PlayerController player;

    private void OnEnable()
    {
        this.stateName = "GamePlayState";
    }

    public override void Enter()
    {
            
    }

    public override void Exit()
    {
        
    }

    public override void FixedUpdateState()
    {
        //this will eventually happen in the partition
        IUpdateable[] list = UpdateManager.Player.GetComponents<IUpdateable>();
        for(int i = 0; i < list.Length; i++)
        {
            list[i].FixedUpdateSelf();
        }
    }

    public override void UpdateState()
    {
        inputHandler.HandleInput();
        ////this will eventually happen in the partition
        IUpdateable[] list = UpdateManager.Player.GetComponents<IUpdateable>();
        for (int i = 0; i < list.Length; i++)
        {
            list[i].UpdateSelf();
        }
    }
}
