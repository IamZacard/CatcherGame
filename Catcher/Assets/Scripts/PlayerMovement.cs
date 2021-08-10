using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerState
{
    walk,
    interact,
    attack,
    stagger,
    idle,
    dash
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidBody;
    private Vector3 change;
    public Animator animator;
    public GameObject projectile;
       

    public float dashSpeed;
    public float dashCount;
    public float startDashCount;

    private SoulManager soulManager;
    public SoulBar soulBar;

    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        myRigidBody = GetComponent<Rigidbody2D>();

        dashCount = startDashCount;
        soulManager = GetComponent<SoulManager>();
        soulBar = GetComponent<SoulBar>();
    }


    void Update()
    {
        Application.targetFrameRate = 60;
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Fire1") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }

        if (Input.GetButtonDown("Dash") && currentState != PlayerState.attack && currentState !=PlayerState.stagger)
        {
            StartCoroutine(DashCo());
        }
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return new WaitForSeconds(.1f);
        CreateArrow();
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.5f);
        currentState = PlayerState.walk;
    }

    private void CreateArrow()
    {
        Vector2 temp = new Vector2(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        Arrow arrow = Instantiate(projectile, transform.position + new Vector3(0, .3f), Quaternion.identity).GetComponent<Arrow>();
        arrow.Setup(temp, ChooseArrowDirection());
    }

    Vector3 ChooseArrowDirection()
    {
        float temp = Mathf.Atan2(animator.GetFloat("moveY"), animator.GetFloat("moveX")) * Mathf.Rad2Deg;
        return new Vector3(0, 0, temp);
    }


    void UpdateAnimationAndMove()
    {
        myRigidBody.velocity = Vector2.zero;
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }


    // dash
          
    private IEnumerator DashCo()
    {
        animator.SetBool("dashing", true);
        currentState = PlayerState.dash;
        yield return null; // new WaitForSeconds(.3f);
        //DashChar();
        Dashing();
        animator.SetBool("dashing", false);
        yield return null; //new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }
          

    void MoveCharacter()
    {
        change.Normalize();
        myRigidBody.MovePosition(transform.position + change * speed * Time.fixedDeltaTime);
    }   


    public void Dashing()
    {
        if (soulManager.GetComponent<SoulManager>().currentSouls != 0)
        {
            dashCount -= Time.deltaTime;
            change.Normalize();
            myRigidBody.MovePosition(transform.position + change * dashSpeed * Time.fixedDeltaTime);
            soulManager.GetComponent<SoulManager>().currentSouls--;            
        }
    }

    /*void DashChar()
    {
        dashCount -= Time.deltaTime;
        change.Normalize();
        myRigidBody.MovePosition(transform.position + change * dashSpeed * Time.fixedDeltaTime);
    }*/
}
