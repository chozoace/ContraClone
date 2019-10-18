using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GamePlayState", menuName = "ScriptableObjects/GameStates/GamePlayState", order = 1)]
public class GamePlayState : GameState
{
    List<Partition> partitions = new List<Partition>();

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
        foreach (Partition partition in partitions)
        {
            for(int gameObjIndex = 0; gameObjIndex < partition.gameObjectList.Count; gameObjIndex++)
            {
                IUpdateable[] list = partition.gameObjectList[gameObjIndex].GetComponents<IUpdateable>();
                for (int i = 0; i < list.Length; i++)
                {
                    list[i].FixedUpdateSelf();
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
            for (int gameObjIndex = 0; gameObjIndex < partition.gameObjectList.Count; gameObjIndex++)
            {
                IUpdateable[] list = partition.gameObjectList[gameObjIndex].GetComponents<IUpdateable>();
                for (int i = 0; i < list.Length; i++)
                {
                    list[i].UpdateSelf();
                }
            }
        }
    }
}
