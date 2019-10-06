using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShooter : IUpdateable
{
    void StartShooting();
    void EndShooting();
    void UpdateShootDirection(Vector2 newShootDirection);
}
