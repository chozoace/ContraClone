using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Actor
{
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    new void Awake()
    {
        base.Awake();
        this.equippedGun = new BasicGun(this);

        shootDirection.x = 1;
    }

    protected override void Update()
    {
       handleInput();
       base.Update();
    }

    void handleInput()
    {
        Action action = InputHandler.Instance().handleInput();
        if(action != null)
        {
            action.execute(this);
        }
    }

    protected override void updateShootDirection()
    {
        //This is temporary until I figure out a way to determine shoot origin based on state of Actor
        shootOrigin = Vector2.zero;
        //shooting straight up idle
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") == 1)
        {
            shootDirection.x = Input.GetAxisRaw("Horizontal");
        }
        shootDirection.y = Input.GetAxisRaw("Vertical");
        //to adjust standing shooting
        if (shootDirection.y == 0)
        {
            shootOrigin = new Vector2(0, 0.05f);
        }
        //to adjust running down shooting
        else if(shootDirection.x != 0 && shootDirection.y < 0)
        {
            shootOrigin = new Vector2(.06f * Input.GetAxisRaw("Horizontal"), 0);
        }
        //crouching shooting
        if (Input.GetAxisRaw("Vertical") == -1 && this.velocity.x == 0)
        {
            shootDirection.y = 0;
            shootOrigin = new Vector2(0, -0.08f);
        }
        animator.SetInteger("aimY", (int)Input.GetAxisRaw("Vertical"));
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        bool flipSprite = spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < -0.01f);
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
}