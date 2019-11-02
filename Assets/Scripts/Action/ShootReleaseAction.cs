using UnityEngine;
using UnityEditor;

public class ShootReleaseAction : Action
{
    public void execute(GameObject obj)
    {
        IShooter shooter = obj.GetComponent<IShooter>();
        if (shooter != null)
            shooter.EndShooting();
        else
            throw new MissingComponentException("GameObject does not implement IShooter");
    }
    public string getActionName()
    {
        return ActionNames.ShootReleaseAction.Value;
    }

}