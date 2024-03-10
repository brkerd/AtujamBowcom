using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 40;
    public Rigidbody2D rb;

    public static PlayerStatus pStatus;


    void Start()
    {
        rb.velocity = transform.right * speed;

        if (pStatus == null)
        {
            GameObject status = GameObject.Find("PlayerStatus");
            pStatus = status.GetComponent<PlayerStatus>();
        }
            


    }
    void OnTriggerEnter2D(Collider2D hitInfo){
        
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.Takedamage(damage);
        }

        if(hitInfo.CompareTag("Player"))
        {
            pStatus.LoseHealth(1f);
            
        }

        Destroy(gameObject);
    }
}
