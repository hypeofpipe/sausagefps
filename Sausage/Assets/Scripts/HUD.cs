using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HUD : MonoBehaviour
{

	public Sprite[] sprites;
	public PhysicsObject hero;
	public SpriteRenderer active;
	private int health;
	
	// Use this for initialization
	void Start () {
		health = hero.getHealth();
		active.sprite = sprites[0];
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		health = hero.getHealth();
		if (health < 80)
		{
			active.sprite = sprites[1];
		}
		else if (health < 60)
		{
			active.sprite = sprites[2];
		}
		else if (health < 40)
		{
			active.sprite = sprites[3];
		}
		else if (health < 20)
		{
			active.sprite = sprites[4];
		}
	}
}
