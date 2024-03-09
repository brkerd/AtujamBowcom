using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    //public int damage = 40;
    public GameObject bulletPrefab;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }    
    }
    void Shoot()
    {
        
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        
        
        
        
        /*RaycastHit2D hitInfo = Physics2D.Raycast(FirePoint.position, FirePoint.right);
        Debug.Log(hitInfo.transform.name);
       
        if(hitInfo)
        {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            
            if(enemy != null)
            {
                enemy.Takedamage(damage);
            }
            
            Instantiate(impactEffect, hitInfo.point, Quaternion.identity);
        }*/
    }   
}
