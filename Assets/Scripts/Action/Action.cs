using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Action
{
    void execute(GameObject obj);
    string getActionName();
}
