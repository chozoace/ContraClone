using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PlayerDeathState", menuName = "ScriptableObjects/GameStates/PlayerDeathState", order = 2)]
public class PlayerDeathState : GameState
{
    List<Partition> partitions = new List<Partition>();

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

    public override void FixedUpdateState()
    {
        foreach (Partition partition in partitions)
        {
            for (int gameObjIndex = 0; gameObjIndex < partition.gameObjectList.Count; gameObjIndex++)
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
