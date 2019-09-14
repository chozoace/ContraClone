using UnityEngine;
using UnityEditor;

public class ShootReleaseAction : Action
{
    public void execute(Actor actor)
    {
        actor.EndShooting();
    }
}