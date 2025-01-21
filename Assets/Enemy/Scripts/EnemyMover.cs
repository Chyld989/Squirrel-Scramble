using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
	[SerializeField] List<Waypoint> Path = new List<Waypoint>();
	[SerializeField] float WaitTime = 1f;

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(FollowPath());
	}

	IEnumerator FollowPath()
	{
		foreach (var waypoint in Path)
		{
			transform.position = waypoint.transform.position;

			yield return new WaitForSeconds(WaitTime);
		}
	}
}
