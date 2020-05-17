using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private int maxHP = 500;
    public int health;
    private PlayerPos position;
    public HealthBar healthBar;
    private bool immune = false; // So the player doesn't take a tick of damage everytime it updates
    private float immuneTime;

    public void takeDamage(int damage)
    {
        if (!immune)
        {
            this.health = this.health - damage;
            immune = true;
            immuneTime = Time.time;
            if (this.health <= 0)
            {
                Die();
            }
            else
            {
                healthBar.SetHealth(this.health);
            }
        }
    }
    void restoreHP(int amount) //restores some health points
    {
        this.health = this.health + amount;
        if (this.health > this.maxHP)
        {
            this.health = this.maxHP;
        }
        healthBar.SetHealth(this.health);
    }
    void Start()
    {
        this.position = new PlayerPos(); // Add player tag and game controller tag
        this.health = this.maxHP;
        this.healthBar.SetMaxHealth(this.maxHP);
    }
    void Update()
    {
        if (immune)
        {
            if (Time.time - immuneTime > 0.5)
            {
                immune = false;
            }
        }
    }
    void Die()
    {
        Destroy(gameObject);
        position.Died();
    }
    void OnTriggerEnter2D(Collider2D hitObject)
    {
        Enemy obj = hitObject.GetComponent<Enemy>();
        if (obj != null)
        {
            this.takeDamage(obj.damageWhenHit);
        }
        LevelCheckpoint checkpoint = hitObject.GetComponent<LevelCheckpoint>();
        if (checkpoint != null)
        {
            string nextSceneName = "scene1"; // Change this to the according level/name
            checkpoint.nextLevel(nextSceneName);
        }
        OutOfBounds bound = hitObject.GetComponent<OutOfBounds>();
        if (bound != null)
        {
            this.Die();
        }
    }
}