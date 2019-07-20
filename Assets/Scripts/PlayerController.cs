using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Actor
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
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

    public override void startShooting()
    {
        animator.SetBool("isShooting", true);
        base.startShooting();
    }

    public override void endShoot()
    {
        animator.SetBool("isShooting", false);
        base.endShoot();
    }

    protected override void updateShootDirection()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            shootDirection.x = Input.GetAxisRaw("Horizontal");
        }
        shootDirection.y = Input.GetAxisRaw("Vertical");
        animator.SetInteger("aimY", (int)shootDirection.y);
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