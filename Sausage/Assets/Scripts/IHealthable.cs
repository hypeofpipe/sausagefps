using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthable
{
	void reduceHealth(int amountInPercents);
	void regenerateHealth(int amountInPercents);
	void kill();
}
