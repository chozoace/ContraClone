﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PlayerDeathState", menuName = "ScriptableObjects/GameStates/PlayerDeathState", order = 2)]
public class PlayerDeathState : GameState
{
    List<Partition> partitions = new List<Partition>();
    public GameStateManager gameStateManager;

    public override void ClearReferences()
    {
        partitions = new List<Partition>();
    }

    private void OnEnable()
    {
        this.stateName = "PlayerDeathState";
    }

    public override void Enter()
    {
        //disable input handler turn on when animation is finished
    }

    public override void Exit()
    {

    }

    public void BeginLevelReset()
    {
        Debug.Log("begin level reset");
        gameStateManager.RestartGameStateReferences();
        Application.LoadLevel(Application.loadedLevel);
    }

    public override void FixedUpdateState()
    {
        foreach (Partition partition in partitions)
        {
            //kept as a for loop, accessing a list when something gets removed triggers error
            for (int gameObjIndex = 0; gameObjIndex < partition.gameObjectList.Count; gameObjIndex++)
            {
                IUpdateable[] list = partition.gameObjectList[gameObjIndex]?.GetComponents<IUpdateable>();
                foreach (IUpdateable updateable in list)
                {
                    updateable.FixedUpdateSelf();
                }
            }
        }
        partitions = worldGrid.GetUpdatablePartitions(Camera.main.gameObject);
    }

    public override void UpdateState()
    {
        inputHandler.HandleInput();
        foreach (Partition partition in partitions)
        {
            //kept as a for loop, accessing a list when something gets removed triggers error
            for (int gameObjIndex = 0; gameObjIndex < partition.gameObjectList.Count; gameObjIndex++)
            {
                IUpdateable[] list = partition.gameObjectList[gameObjIndex]?.GetComponents<IUpdateable>();
                foreach (IUpdateable updateable in list)
                {
                    updateable.UpdateSelf();
                }
                partition.gameObjectList[gameObjIndex]?.GetComponent<Animator>()?.Update(Time.deltaTime);
            }
        }
    }
}
