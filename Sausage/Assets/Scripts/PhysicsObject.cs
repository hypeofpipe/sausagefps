using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PhysicsObject : MonoBehaviour, IHealthable
{
    private Rigidbody2D rb;
    public float forceMultiplier = 0.5f;
    private int healthInPercents = 100;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
          changePosition(Vector2.up, forceMultiplier);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            changePosition(Vector2.down, forceMultiplier);  
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            changePosition(Vector2.left, forceMultiplier);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            changePosition(Vector2.right, forceMultiplier);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameObject.FindGameObjectsWithTag("Enemies").Length > 0)
            {
                attack( GameObject.FindGameObjectsWithTag("Enemies") );   
            }
        }
        
    }

    private void attack(GameObject[] enemies)
    {
        GameObject closest = null;
        float distance = 10f;
        Vector3 position = transform.position;
        foreach (GameObject go in enemies) {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance) {
                closest = go;
                distance = curDistance;
            }
        }

        if (closest != null)
        {
            closest.GetComponent<Enemy>().reduceHealth(20);
        }
 
    }

    private void changePosition(Vector2 direction, float multiplier)
    {
        rb.AddForce(direction * multiplier, ForceMode2D.Impulse);
    }

    public void reduceHealth(int amountInPercents)
    {
        if (healthInPercents - amountInPercents > 0)
        {
            healthInPercents = healthInPercents - amountInPercents;    
        }
        else
        {
            kill();
        }
    }

    public void regenerateHealth(int amountInPercents)
    {
        if (healthInPercents + amountInPercents > 0)
        {
            healthInPercents = healthInPercents + amountInPercents;    
        }
    }

    public void kill()
    {
        Destroy(gameObject);
    }
}
