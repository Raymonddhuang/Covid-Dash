using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 20f;
    public int damage = 50;
    public Rigidbody2D body;

    void Start()
    {
        body.velocity = transform.right * bulletSpeed;
    }

    void OnTriggerEnter2D(Collider2D hitObject)
    {
        Enemy target = hitObject.GetComponent<Enemy>();
        if (target != null)
        {
            target.takeDamage(damage);
        }
        Destroy(gameObject);
    }
}