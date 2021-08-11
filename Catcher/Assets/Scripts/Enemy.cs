using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attacking,
    stagger,
    death
}

public class Enemy : MonoBehaviour
{
    public EnemyState CurrentState;
    private Vector2 movement;
           
    private void Awake()
    {
        
    }


}



