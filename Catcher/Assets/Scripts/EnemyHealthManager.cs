using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public GameObject soul;

    public int enemyMaxHealth;
    public int enemyCurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCurrentHealth <= 0)
        {
            Destroy(gameObject);
            CreateSoul();
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        enemyCurrentHealth -= damageToGive;
    }

    private void CreateSoul()
    {
        // Vector2 temp = new Vector2(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        Instantiate(soul, transform.position + new Vector3(0, 0), Quaternion.identity);
    }
}
