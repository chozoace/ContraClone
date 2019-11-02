using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IActionable
{
    void ExecuteAction(Action action);
    void SetLockedActions(List<string> lockedActions);
    List<string> GetLockedActions();
    void StopHitstun();
}
