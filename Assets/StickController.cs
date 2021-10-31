using System;
using UnityEngine;

public class StickController : MonoBehaviour
{
	public Transform colliderPosition;
	[SerializeField] private float speed;
	
	public bool Grow { get; set; }

	private void Update()
	{
		if (Grow)
		{
			var scale = transform.localScale;
			scale.y += speed * Time.deltaTime;
			transform.localScale = scale;
		}
	}
}