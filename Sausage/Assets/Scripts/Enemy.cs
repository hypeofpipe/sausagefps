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
	void Update ()
	{
		walk();
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
