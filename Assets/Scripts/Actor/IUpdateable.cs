using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpdateable
{
    void UpdateSelf();
    void FixedUpdateSelf();
}
