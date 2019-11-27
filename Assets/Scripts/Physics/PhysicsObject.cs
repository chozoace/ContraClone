using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    [SerializeField] public float maxSpeed = 7;
    [SerializeField] public float jumpTakeOffSpeed = 7;

    private Vector2 inputDir = Vector2.zero;
    public Vector2 InputDir { get { return inputDir; } set { inputDir = value; } }
    private Vector2 oldPos = Vector2.zero;
    public Vector2 OldPos { get { return oldPos; } set { oldPos = value; } }

    public float minGroundNormalY = .2f;
    public float gravityModifier = 1f;

    private Vector2 targetVelocity;
    private bool grounded;
    public bool IsGrounded { get { return grounded; } }
    private Vector2 groundNormal;
    private Rigidbody2D rb2d;
    private Vector2 velocity;
    public Vector2 Velocity { get { return velocity; } set { velocity = value; } }
    private ContactFilter2D contactFilter;
    private RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    private List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);

    private const float minMoveDistance = 0.001f;
    private const float shellRadius = 0.01f;

    private IPhysics physicsComponent;

    private void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
        physicsComponent = GetComponent<IPhysics>();
        if (physicsComponent == null)
        {
            throw new MissingComponentException("GameObject does not implement IPhysics");
        }

        oldPos = this.gameObject.transform.position;
    }

    private void Start()
    {
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }

    public void PhysicsUpdate()
    {
        targetVelocity = Vector2.zero;
        targetVelocity = physicsComponent.ComputeVelocity(velocity, grounded, maxSpeed);
        velocity.y = targetVelocity.y;
    }

    public void PhysicsFixedUpdate()
    {
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
        velocity.x = targetVelocity.x;

        grounded = false;

        Vector2 deltaPosition = velocity * Time.deltaTime;
        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);
        Vector2 move = moveAlongGround * deltaPosition.x;

        Movement(move, false);

        move = Vector2.up * deltaPosition.y;

        Movement(move, true);

        physicsComponent.UpdateGridPosition(oldPos);
        oldPos = rb2d.position;
    }

    void Movement(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;

        if (distance > minMoveDistance)
        {
            int count = rb2d.Cast(move, contactFilter, hitBuffer, distance + shellRadius);
            hitBufferList.Clear();
            for (int i = 0; i < count; i++)
            {
                hitBufferList.Add(hitBuffer[i]);
            }

            for (int i = 0; i < hitBufferList.Count; i++)
            {
                Vector2 currentNormal = hitBufferList[i].normal;
                if (currentNormal.y > minGroundNormalY) //.65f 65 degrees
                {
                    grounded = true;
                    if (yMovement)
                    {
                        groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                //if dot product of velocity and colliding normal is negative,
                //multiply dot product with colliding normal and subtract it from current velocity?
                //to cancel out part of velocity that would cancel out movement totally when hitting head on angled ceiling 
                float projection = Vector2.Dot(velocity, currentNormal);
                if (projection < 0)
                {
                    velocity = velocity - projection * currentNormal;
                }

                float modifiedDistance = hitBufferList[i].distance - shellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }
        }
        rb2d.position = rb2d.position + move.normalized * distance;
    }
}
