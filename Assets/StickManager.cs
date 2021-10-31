using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class StickManager : MonoBehaviour
{
	[SerializeField] private StickController stickPrefab;
	[SerializeField] private PillarManager pillarManager;
	[SerializeField] private Transform targetRotate;
	[SerializeField] private AnimationController animationController;
	[SerializeField] private ColliderDetect colliderDetect;
	[SerializeField] private float offsetX;

	private StickController _current;

	private void Start()
	{
		Create();
	}

	public void Create()
	{
		var position = pillarManager.CurrentPillarPosition;
		position.x += offsetX;
		var stick = Instantiate(stickPrefab, position, quaternion.identity);
		_current = stick;
	}

	public void OnPointerDown()
	{
		_current.Grow = true;
	}

	public void OnPointerUp()
	{
		_current.Grow = false;

		IEnumerator Do()
		{
			var rotate = animationController.Rotate(_current.transform, targetRotate);
			yield return rotate;
			yield return null;
			colliderDetect.LevelController(_current.colliderPosition.position);
			yield return new WaitForSeconds(.1f);
			if (colliderDetect.LevelPass)
				pillarManager.NextLevel();
			else
				Debug.Log("Game Over");
		}

		StartCoroutine(Do());
	}
}