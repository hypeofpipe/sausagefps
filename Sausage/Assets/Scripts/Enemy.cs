using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHealthable
{
	public int healthInPercents = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
