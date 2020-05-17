using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int damageWhenHit = 100; // The damage the player takes if they get hit 
    public GameObject deathAnimation;
    public Rigidbody2D body;

    public void takeDamage(int damage)
    {
        this.health = this.health - damage;
        if (this.health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        //Instantiate(deathAnimation,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }

    /*void OnTriggerEnter2D(Collider2D hitObject)
    {
        PlayerControls player = hitObject.GetComponent<PlayerControls>();
        if (player != null)
        {
            player.takeDamage(damageWhenHit);
        }
    }*/
}