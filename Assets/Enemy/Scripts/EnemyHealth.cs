using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	[SerializeField] int MaxHitPoints = 5;
	[SerializeField] int CurrentHitPoints = 0;
	// Start is called before the first frame update
	void Start()
	{
		CurrentHitPoints = MaxHitPoints;
	}

	private void OnParticleCollision(GameObject other)
	{
		// TODO: Figure out why not registering as a hit if tower is too far from enemy
		Debug.Log("Hit");
		ProcessHit();
	}

	private void ProcessHit()
	{
		CurrentHitPoints--;
		if (CurrentHitPoints <= 0)
		{
			Destroy(gameObject);
		}
	}
}
