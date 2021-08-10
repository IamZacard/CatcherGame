using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWorm : Enemy
{
    private Rigidbody2D MyRigidBody;
    public Transform Target;

    public float moveSpeed;

    public float ChaseRadius;
    public float AttackRadius;

    
    public int BaseAttack;

    
    public Animator Anim;

    void Start()
    {
        CurrentState = EnemyState.idle;
        MyRigidBody = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Target = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(Target.position, transform.position) <= ChaseRadius && Vector3.Distance(Target.position, transform.position) > AttackRadius)
        {
            if (CurrentState == EnemyState.idle || CurrentState == EnemyState.walk && CurrentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, Target.position, moveSpeed * Time.fixedDeltaTime);
                ChangeAnim(temp - transform.position);
                MyRigidBody.MovePosition(temp);
                ChangeState(EnemyState.walk);
                Anim.SetBool("moving", true);
            }
            else if (Vector3.Distance(Target.position, transform.position) > ChaseRadius)
            {
                Anim.SetBool("moving", false);
            }

            if(Vector3.Distance(Target.position, transform.position) <= AttackRadius)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, Target.position, moveSpeed * Time.fixedDeltaTime);
                ChangeAnim(temp - transform.position);
                MyRigidBody.MovePosition(temp);
                ChangeState(EnemyState.attack);
                Anim.SetBool("attacking", true);
            }
            else
            {
                Anim.SetBool("attacking", false);
            }
        }
    }

    private void SetAnimFloat(Vector2 SetVector)
    {
        Anim.SetFloat("moveX", SetVector.x);
        Anim.SetFloat("moveY", SetVector.y);
    }

    private void ChangeAnim(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }
            else if (direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }

    private void ChangeState(EnemyState NewState)
    {
        if (CurrentState != NewState)
        {
            CurrentState = NewState;
        }
    }
}
