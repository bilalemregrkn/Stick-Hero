using System.Collections;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
	[SerializeField] private float animationTime;

	public IEnumerator Move(Transform currentTransform, Vector3 target, float time = 0)
	{
		time = time == 0 ? animationTime : time;
		var passed = 0f;
		var init = currentTransform.transform.position;
		while (passed < time)
		{
			passed += Time.deltaTime;
			var normalized = passed / time;
			var current = Vector3.Lerp(init, target, normalized);
			currentTransform.position = current;
			yield return null;
		}
	}

	public IEnumerator Scale(Transform currentTransform, Vector3 target, float time = 0)
	{
		time = time == 0 ? animationTime : time;
		var passed = 0f;
		var init = currentTransform.transform.localScale;
		while (passed < time)
		{
			passed += Time.deltaTime;
			var normalized = passed / time;
			var current = Vector3.Lerp(init, target, normalized);
			currentTransform.localScale = current;
			yield return null;
		}
	}

	public IEnumerator Rotate(Transform currentTransform, Transform target, float time = 0)
	{
		time = time == 0 ? animationTime : time;
		var passed = 0f;
		var init = currentTransform.rotation;
		while (passed < time)
		{
			passed += Time.deltaTime;
			var normalized = passed / time;
			var current = Quaternion.Lerp(init, target.rotation, normalized);
			currentTransform.rotation = current;
			yield return null;
		}
	}
}