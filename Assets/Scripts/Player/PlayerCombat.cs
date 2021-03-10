using System;
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
    public float player_health = 100;
    Rigidbody2D player_body;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        Hurt();
    }
    
    void Attack()
    {
        //Check for Melee Attack  type, set damage, and play appropriate Animation
        Debug.Log("Current Weapon is:" + this.GetComponent<Inventory>().GetMeleeString());
        string meleeWeapon = this.GetComponent<Inventory>().GetMeleeString();

        //Checks current weapon to determine attack damage and the animation that needs to be played
        if (meleeWeapon == "none")
        {
            attackDamage = 10;
            animator.SetTrigger("Punch_Attack");
        }
        else if (meleeWeapon == "Knife")
        {
            attackDamage = 20;
            animator.SetTrigger("Knife_Attack");
        }
        else if (meleeWeapon == "Spear")
        {
            attackDamage = 30;
            animator.SetTrigger("Spear_Attack");
        }else if (meleeWeapon == "Trident")
        {
            attackDamage = 40;
            animator.SetTrigger("Trident_Attack");
        }
        
        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //Damage the enemies
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
            enemy.GetComponent<Interactable>().TakeDamage(attackDamage);
            Debug.Log(enemy.name + "took " + attackDamage + " points of damage!");
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
