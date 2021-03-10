<<<<<<< Updated upstream:Assets/Scripts/PlayerCombat.cs
﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public Transform damagePoint; //Notes the location of which NUE is damaged if touched by enemy collider
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 10;

    public float damageRange = 0.5f;
    public int hurtDamage = 10;

    // Update is called once per frame
    public float player_health_max = 100;
    public float player_hunger_max = 100;
    public float player_health;
    public float player_hunger;

    public HealthBar healthBar;
    public HungerBar hungerBar;

    //Audio source for sound effects
    public AudioSource punch;
    public AudioSource gun;
    public AudioSource hurt;
    public AudioSource slash;

    void Start()
    {
        player_health = player_health_max;
        player_hunger = player_hunger_max;
        healthBar.SetMaxHealth(player_health_max);
        hungerBar.SetMaxHunger(player_hunger_max);
        //punch = GetComponent<AudioSource>();
        //gun = GetComponent<AudioSource>();
        //hurt = GetComponent<AudioSource>();
        //slash = GetComponent<AudioSource>();
    }

    Rigidbody2D player_body;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
            TestHealth();
            
        }
        HungerHeal();
        Hurt();

        //These Next two functions were made to test the health and hunger bars
        if(Input.GetKeyDown(KeyCode.O))
        {
            TestHealth();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            TestHunger();
        }
    }

    void TestHealth()
    {
        player_health -= 10;
        healthBar.SetHealth(player_health);
    }
    void TestHunger()
    {
        player_hunger -= 10;
        hungerBar.SetHunger(player_hunger);
    }

    //This function heals the player if hunger meter is full
    void HungerHeal()
    {
        if(player_hunger == player_hunger_max)
        {
            if(player_health < player_health_max)
            {
                player_health += 2;
                healthBar.SetHealth(player_health);
            }
        }
    }
    void Attack()
    {
        //Play Attack Animation
        animator.SetTrigger("Punch_Attack");
        punch.Play();
        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //Damage the enemies
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            
        }
        
    }

    //Makes Player invulnerable if hit recently
    DateTime invincible = DateTime.Now;
    void Hurt()
    {
        //Play Hurt Animation

        //Detect enemies who are touching the player
        Collider2D[] enemiesContact = Physics2D.OverlapCircleAll(damagePoint.position, damageRange, enemyLayers);

        //Check to see if player is still invincible, if so, see if the contact point is NUE or Enemies
        if (invincible <= DateTime.Now)
        {
            foreach (Collider2D touching in enemiesContact)
            {
                //Ignore if the colliding body is NUE's
                if (touching.name == "Nue_Player")
                    Debug.Log("No damage dealt, touched Player's 2DBody");
                //
                else
                {
                    Debug.Log("We got hit by " + touching.name);
                    player_health = player_health - 10;
                    healthBar.SetHealth(player_health);
                    invincible = DateTime.Now.AddSeconds(2);//Change this value to alter invulnerability time
                }
            }
        }
    }


    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        if (damagePoint == null)
            return;
        else
        {
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
            Gizmos.DrawWireSphere(damagePoint.position, damageRange);
        }
    }
}
=======
﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public Transform damagePoint; //Notes the location of which NUE is damaged if touched by enemy collider
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 10;

    public float damageRange = 0.5f;
    public int hurtDamage = 10;

    // Update is called once per frame
    public float player_health_max = 100;
    public float player_hunger_max = 100;
    public float player_health;
    public float player_hunger;

    public HealthBar healthBar;
    public HungerBar hungerBar;

    Rigidbody2D player_body;

    void Start()
    {
        player_health = player_health_max;
        player_hunger = player_hunger_max;
        healthBar.SetMaxHealth(player_health_max);
        hungerBar.SetMaxHunger(player_hunger_max);
        //punch = GetComponent<AudioSource>();
        //gun = GetComponent<AudioSource>();
        //hurt = GetComponent<AudioSource>();
        //slash = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        Hurt();
        HungerHeal();
    }

    public float GetHealth()
    {
        return player_health;
    }
    public float GetHunger()
    {
        return player_hunger;
    }
    
    public float GetHealthMax()
    {
        return player_health_max;
    }
    public float GetHungerMax()
    {
        return player_hunger_max;
    }
    
    public void SetHunger(float hunger)
    {
        player_hunger += hunger;
        if(player_hunger > player_hunger_max)
        {
            player_hunger = player_hunger_max;
        }
        hungerBar.SetHunger(player_hunger);
    }

    public void SetHealth(float heal)
    {

    }
    void Attack()
    {
        //Play Attack Animation
        animator.SetTrigger("Punch_Attack");
        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //Damage the enemies
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
            enemy.GetComponent<Interactable>().TakeDamage(attackDamage);
        }
    }

    //Makes Player invulnerable if hit recently
    DateTime invincible = DateTime.Now;
    void Hurt()
    {
        //Play Hurt Animation

        //Detect enemies who are touching the player
        Collider2D[] enemiesContact = Physics2D.OverlapCircleAll(damagePoint.position, damageRange, enemyLayers);
        
        //Check to see if player is still invincible, if so, see if the contact point is NUE or Enemies
        if(invincible <= DateTime.Now){
            foreach (Collider2D touching in enemiesContact)
            {
                //Ignore if the colliding body is NUE's
                if (touching.name == "Nue_Player")
                    Debug.Log("No damage dealt, touched Player's 2DBody");
                //
                else
                {
                    Debug.Log("We got hit by " + touching.name);
                    player_health = player_health - 10;
                    healthBar.SetHealth(player_health);
                    invincible = DateTime.Now.AddSeconds(2);//Change this value to alter invulnerability time
                }
            }
        }
    }

    void HungerHeal()
    {
        if (player_hunger == player_hunger_max && player_health < player_health_max)
        {
            player_health += 0.002f;
            healthBar.SetHealth(player_health);
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        if (damagePoint == null)
            return;
        else
        {
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
            Gizmos.DrawWireSphere(damagePoint.position, damageRange);
        }
    }
}
>>>>>>> Stashed changes:Assets/Scripts/Player/PlayerCombat.cs
