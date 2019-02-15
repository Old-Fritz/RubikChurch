using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CubePart : MonoBehaviour
{

	private Vector3 startPosition;
	// Use this for initialization
	void Start ()
	{
		startPosition = transform.localPosition;
	}

	public bool checkCorrect()
	{
		// check if start and current positions are equal
		float epsilon = 0.0001f;
		Vector3 difference = transform.localPosition - startPosition;
		if (Math.Abs(difference.x) < epsilon && Math.Abs(difference.y) < epsilon && Math.Abs(difference.z) < epsilon)
			return true;
		return false;
	}
}
