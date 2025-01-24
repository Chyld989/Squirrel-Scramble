using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
	[SerializeField] Color DefaultColor = Color.white;
	[SerializeField] Color BlockedColor = Color.gray;

	TextMeshPro Label;
	Vector2Int Coordinates = new Vector2Int();
	Waypoint Waypoint;

	void OnEnable()
	{
		Label = GetComponent<TextMeshPro>();
		Label.enabled = false;
		Waypoint = GetComponentInParent<Waypoint>();
		DisplayCurrentCoordinates();
	}

	// Update is called once per frame
	void Update()
	{
		if (Application.isPlaying == false)
		{
			DisplayCurrentCoordinates();
			UpdateObjectName();
		}

		ToggleLabels();
		ColorCoordinates();
	}

	private void ToggleLabels()
	{
		if (Input.GetKeyDown(KeyCode.D))
		{
			Label.enabled = !Label.enabled;
		}
	}

	private void ColorCoordinates()
	{
		if (Waypoint.GetIsPlaceable())
		{
			Label.color = DefaultColor;
		}
		else
		{
			Label.color = BlockedColor;
		}
	}

	void DisplayCurrentCoordinates()
	{
		Coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
		Coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

		Label.text = $@"{Coordinates.x},{Coordinates.y}";
	}

	void UpdateObjectName()
	{
		transform.parent.name = Coordinates.ToString();
	}
}
