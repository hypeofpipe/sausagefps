using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHealthable
{
	public int healthInPercents = 100;
	public float multiplier = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		walk();
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		attack(GameObject.FindGameObjectsWithTag("Hero"));
	}

	private void walk()
	{
		var heroPos = GameObject.FindGameObjectWithTag("Hero").transform.position;
		Vector3 endVector = Vector3.zero;
		if (heroPos.x - transform.position.x < 0)
		{
			endVector = new Vector3(-1, 0, 0);
		}
		else if (heroPos.x - transform.position.x > 0)
		{
			endVector = new Vector3(1, 0, 0);
		}
		transform.Translate(
			endVector * multiplier
			);
	}

	private void attack(GameObject[] enemies)
	{
		GameObject closest = null;
		float distance = 5f;
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
			closest.GetComponentInChildren<PhysicsObject>().reduceHealth(30);
			closest.GetComponentInChildren<Rigidbody2D>().AddForce(new Vector2(-20f, 10f), ForceMode2D.Impulse);
		}
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
