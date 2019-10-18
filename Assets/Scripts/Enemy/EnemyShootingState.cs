using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyShootingState : EnemyState
{
    private GameObject playerObject;
    private float alertRange = 2f;

    public EnemyShootingState(EnemyStateManager stateManager) : base(stateManager) { }

    public override void Enter()
    {

    }

    public override void Exit()
    {

    }

    public override void UpdateState()
    {
        Debug.Log("enemy shoot");
        if (playerObject == null)
        {
            List<Partition> partitions = stateManager.WorldGrid.GetUpdatablePartitions(Camera.main.gameObject);
            foreach (Partition partition in partitions)
            {
                for (int gameObjIndex = 0; gameObjIndex < partition.gameObjectList.Count; gameObjIndex++)
                {
                    if (partition.gameObjectList[gameObjIndex].tag == "Player")
                    {
                        playerObject = partition.gameObjectList[gameObjIndex];
                        break;
                    }
                }
                if (playerObject != null) break;
            }
        }
        else
        {
            if (Mathf.Abs(playerObject.transform.position.x - stateManager.gameObject.transform.position.x) > alertRange)
            {
                stateManager.ChangeState(EnemyStatesEnum.EnemyWait);
            }
        }
    }

    public override void FixedUpdateState()
    {

    }
}
