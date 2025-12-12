using Unity.Mathematics;
using UnityEngine;

public class Enemy : Damageable
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 1f;
    [SerializeField] private int collisionDamage = 1;
     
    void Start()
    {
        rb.linearVelocity = Vector2.down * speed;  
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable player = collision.gameObject.GetComponent<PlayerMovement>();
        if(player != null)
        {
           player.TakeDamage(collisionDamage);

        }  
        else if(collision.gameObject.CompareTag("PlayerBullet")== false)
        {
            Die();
        }                                           
    }
}