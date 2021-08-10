using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public int playerMaxHealth;
    public int playerCurrentHealth;

    public HealthBar healthBar;

    // GetComponent<PlayerMovement>().Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // animator = GetComponent<Animator>();
        playerCurrentHealth = playerMaxHealth;
        healthBar.SetMaxHealth(playerMaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerCurrentHealth <= 0)
        {
            // animator.SetBool(isDead, true);

            gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void HurtPlayer(int damageToGive)
    {
        playerCurrentHealth -= damageToGive;
        healthBar.SetHealth(playerCurrentHealth);
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }
}
