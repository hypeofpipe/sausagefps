using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PhysicsObject : MonoBehaviour, IHealthable
{
    private Rigidbody2D rb;
    private Animator animator;
    private Animator attackAnimator;
    public Quaternion forceMultiplier = new Quaternion(0.5f, 0.5f, 0.5f, 0.5f);
    public int healthInPercents = 100;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        attackAnimator = GameObject.Find("Attack").GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector2.up * forceMultiplier.x, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(Vector2.down * forceMultiplier.y, ForceMode2D.Impulse); 
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (var o in GetComponentsInChildren<Transform>())
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            animator.CrossFade("BodyAnim", 2.0f);
            rb.AddForce(new Vector2(-1, 0) * forceMultiplier.z, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            foreach (var renderer in GetComponentsInChildren<SpriteRenderer>())
            {
                renderer.flipX = true;
            }

            animator.CrossFade("BodyAnim", 2.0f);
            rb.AddForce(new Vector2(1, 0) * forceMultiplier.w, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameObject.FindGameObjectsWithTag("Enemies").Length > 0)
            {
                attackAnimator.CrossFade("SwordFight", 1.0f);
                attack( GameObject.FindGameObjectsWithTag("Enemies") );   
            }
            else
            {
                attackAnimator.CrossFade("SwordFight", 0.5f);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
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
        GetComponent<Transform>().Translate(new Vector3(direction.x, direction.y, 0) * multiplier);
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

    public int getHealth()
    {
        return healthInPercents;
    }
}
