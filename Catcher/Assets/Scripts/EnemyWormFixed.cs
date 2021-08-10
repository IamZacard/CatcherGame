using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyWormFixed : Enemy
{
    private Rigidbody2D MyRigidBody;
    public Transform target;

    public float moveSpeed;

    public float chaseRadius;
    public float attackRadius;

    
    public int BaseAttack;

    
    private Animator anim;

    void Start()
    {        
        MyRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        Attack();
        checkDistance();        
    }

    void checkDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius 
            && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.fixedDeltaTime);
            ChangeAnim(temp - transform.position);
            MyRigidBody.MovePosition(temp);
            anim.SetBool("moving", true);          
        }
        else if (Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            anim.SetBool("moving", false);
        }
    }

    void Attack()
    {
        if (Vector3.Distance(target.position, transform.position) <= attackRadius)
        {
            anim.SetBool("attacking", true);
        }
        else
        {
            anim.SetBool("attacking", false);
        }
    }

    private void ChangeAnim(Vector2 direction)
    {
        {
            direction = direction.normalized;
            anim.SetFloat("moveX", direction.x);
            anim.SetFloat("moveY", direction.y);
        }
    }              
    
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
