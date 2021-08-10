using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger,
    death
}

public class Enemy : MonoBehaviour
{
    public EnemyState CurrentState;
    private Vector2 movement;

    
    private float Health;

    
    private void Awake()
    {
        
    }

    private void TakeDamage(float Damage)
    {
        Health -= Damage;
        if (Health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }   

}



