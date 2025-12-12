using System.Data;
using UnityEngine;

public class DamageBooster : MonoBehaviour
{
    [SerializeField] StatType type;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
        if(player!=null)
        {
            player.Increment(type);
            Destroy(gameObject);
        }       
    }

}
    public enum StatType
    {
        Damage,
        Speed
    }
