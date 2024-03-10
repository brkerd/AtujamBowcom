using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_enemy : MonoBehaviour
{
    public Transform FirePoint;
    //public int damage = 40;
    public GameObject bulletPrefab;

    public int interval = 3;
    private float time = 0f;

    void Update()
    {
        time += Time.deltaTime;
        if(time >= interval)
        {
        time -= interval;
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
