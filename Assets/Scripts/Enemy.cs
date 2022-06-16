using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 20;
    
    public int currentHealth;
    public float speed = -3f;
    public Rigidbody2D rb;


    void Start()
    {
        
        currentHealth = maxHealth;
    
    }

    public void FixedUpdate()
    {
        rb.velocity = transform.right * speed;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
            if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    { 
        //Instantiate(deathEffect, transform.position,Quaternion.identity);
        //gameObject.SetActive(false);
         Destroy(gameObject);
        //gameObject.transform.position = new Vector2(225f,25f);
        
        

    }


}
