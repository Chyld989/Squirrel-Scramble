using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
	TextMeshPro Label;
	Vector2Int Coordinates = new Vector2Int();

	void OnEnable()
	{
		Label = GetComponent<TextMeshPro>();
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
