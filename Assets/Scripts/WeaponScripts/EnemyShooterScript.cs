using UnityEngine;
using System.Collections;

public class EnemyShooterScript : BaseShooterScript
{
    public override void UpdateShootDirection(Vector2 newShootDirection)
    {
        shootOrigin = Vector2.zero;
        //shooting straight up idle
        if (newShootDirection.x != 0 || newShootDirection.y == 1)
        {
            shootDirection.x = newShootDirection.x;
        }
        shootDirection.y = newShootDirection.y;
        //to adjust standing shooting
        if (shootDirection.y == 0)
        {
            shootOrigin = new Vector2(0, 0.05f);
        }
        //to adjust running down shooting
        else if (shootDirection.x != 0 && shootDirection.y < 0)
        {
            shootOrigin = new Vector2(.06f * newShootDirection.x, 0);
        }
        //straight down shooting?

        shootOrigin = (Vector2)this.gameObject.transform.position + shootOrigin;
        animator.SetInteger("aimY", (int)newShootDirection.y);
        animator.SetInteger("aimX", (int)newShootDirection.x);
    }
}
