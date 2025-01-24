using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
	[SerializeField] GameObject TowerPrefab;
	[SerializeField] bool IsPlaceable;

	public bool GetIsPlaceable()
	{
		return IsPlaceable;
	}

	private void OnMouseDown()
	{
		if (IsPlaceable)
		{
			Instantiate(TowerPrefab, transform.position, Quaternion.identity);
			IsPlaceable = false;
		}
	}
}
