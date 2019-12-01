using UnityEngine;
using System.Collections;

public class EnemyShooterScript : BaseShooterScript
{
    public override void UpdateShootDirection(Vector2 newShootDirection)
    {
        //shooting straight up idle
        if (newShootDirection.x != 0 || newShootDirection.y == 1)
        {
            shootDirection.x = newShootDirection.x;
        }
        //shooting while standing still
        else if (newShootDirection.x == 0 && newShootDirection.y == 0)
        {
            shootDirection.x = transform.rotation.eulerAngles.y == 180 ? -1 : 1;
        }
        shootDirection.y = newShootDirection.y;
        //straight down shooting?

        shootOrigin = this.shootOriginObject.transform.position;
        animator.SetInteger("aimY", (int)newShootDirection.y);
        animator.SetInteger("aimX", (int)newShootDirection.x);
    }
}
