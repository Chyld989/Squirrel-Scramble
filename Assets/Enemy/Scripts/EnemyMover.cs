using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
	[SerializeField] List<Waypoint> Path = new List<Waypoint>();
	[SerializeField] [Range(0f, 5f)] float Speed = 1f;

	// Start is called before the first frame update
	void Start()
	{
		transform.position = Path[0].transform.position;

		StartCoroutine(FollowPath());
	}

	IEnumerator FollowPath()
	{
		foreach (var waypoint in Path)
		{
			var startPosition = transform.position;
			var endPosition = waypoint.transform.position;
			var travelPercent = 0f;

			transform.LookAt(endPosition);

			while (travelPercent < 1f)
			{
				travelPercent += Time.deltaTime * Speed;
				transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);

				yield return new WaitForEndOfFrame();
			}
		}
	}
}
