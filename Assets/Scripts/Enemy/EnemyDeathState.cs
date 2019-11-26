using UnityEngine;
using System.Collections;

public class EnemyDeathState : EnemyState
{
    public EnemyDeathState(EnemyStateManager stateManager) : base(stateManager) { }

    public override void Enter()
    {
        stateManager.gameObject.GetComponent<IPhysics>().OnDeath();
    }

    public override void Exit()
    {
    }

    public override void FixedUpdateState()
    {
    }

    public override void UpdateState()
    {
    }
}
