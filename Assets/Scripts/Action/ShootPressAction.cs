using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPressAction : Action
{
    public void execute(GameObject obj)
    {
        IShooter shooter = obj.GetComponent<IShooter>();
        if (shooter != null)
            shooter.StartShooting();
        else
            throw new MissingComponentException("This GameObject does not implement IShooter");
    }

    public string getActionName()
    {
        return ActionNames.ShootPressAction.Value;
    }
}

