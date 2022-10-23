using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody projectileBody;
    private float damage = 1f;
    private bool isActive;

    public void Initialize(Vector3 direction)
    {
        isActive = true;
        projectileBody.AddForce(direction);
    }
    
    private void Update()
    {
        if (isActive)
        {
            
            //transform.Translate(transform.forward * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //this was a paaaaain. this changed the turn every time the projectile collided with any other collider.
        /*GameObject collisionObject = collision.gameObject;
        TurnManager.GetInstance().ChangeTurn();*/

        if (collision.gameObject.CompareTag("Player"))
        {
            HealthBar Temp = collision.collider.gameObject.GetComponent<HealthBar>();
            if (Temp)
            {
                Temp.wasHit(damage);
            }
        }
    }
}

