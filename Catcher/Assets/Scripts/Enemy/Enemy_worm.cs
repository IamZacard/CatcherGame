using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_worm : MonoBehaviour
{
    private Rigidbody2D MyRigidBody;
    public Transform target;

    public GameObject FireBall;

    public float speed;

    public float chaseRadius;
    public float attackRadius;

    //private float timeBtwAttack;
    //public float startTimeBtwAttack;

    //private float stopTime;
    //public float startStopTime;
    //public float normalSpeed;


    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, target.position) <= chaseRadius && Vector3.Distance(transform.position, target.position) > attackRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("moving", false);
        }

        if (Vector3.Distance(target.position, transform.position) <= attackRadius)
        {
            Shoot();
            anim.SetBool("attacking", true);
        }
        else
        {
            anim.SetBool("attacking", false);
        }
    }

    public void Shoot()
    {
        Vector2 temp = new Vector2(anim.GetFloat("moveX"), anim.GetFloat("moveY"));
        GameObject go = Instantiate(FireBall, target.position, Quaternion.identity);
        go.GetComponent<FireBall>().Setup(temp, ChooseFireBallDirection());
    }

    Vector3 ChooseFireBallDirection()
    {
        float temp = Mathf.Atan2(anim.GetFloat("moveY"), anim.GetFloat("moveX")) * Mathf.Rad2Deg;
        return new Vector3(0, 0, temp);
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

