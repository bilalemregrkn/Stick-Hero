using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class PillarManager : MonoBehaviour
{
	[SerializeField] private PillarController pillarPrefab;
	[SerializeField] private AnimationController animationController;
	[SerializeField] private StickManager stickManager;
	[SerializeField] private Transform spawnPoint;

	[SerializeField] private Transform targetMin;
	[SerializeField] private Transform targetMax;

	[SerializeField] private Transform camera;

	public Vector3 CurrentPillarPosition => current.transform.position;
	[SerializeField] private PillarController current;
	private PillarController _targetPillar;

	private Vector3 _offsetCamera;

	private void Start()
	{
		_offsetCamera = camera.transform.position - current.transform.position;

		Create();
	}

	[ContextMenu(nameof(Create))]
	public void Create()
	{
		var pillar = Instantiate(pillarPrefab);

		//SetPosition
		ChangePositionX(pillar.transform, spawnPoint.position.x);

		//SetScale
		pillar.SetRandomSize();

		//SetTarget
		var targetX = Random.Range(targetMin.position.x, targetMax.position.x);
		var targetPosition = pillar.transform.position;
		targetPosition.x = targetX;
		var move = animationController.Move(pillar.transform, targetPosition);

		//Animation
		StartCoroutine(move);

		//SetTarget
		_targetPillar = pillar;
	}

	private void ChangePositionX(Transform current, float x)
	{
		var position = current.transform.position;
		position.x = x;
		current.transform.position = position;
	}

	public void NextLevel()
	{
		GameManager.Instance.Score++;
		current = _targetPillar;

		//Camera Animation
		var targetPosition = current.transform.position + _offsetCamera;
		var move = animationController.Move(camera, targetPosition, .2f);
		StartCoroutine(move);

		IEnumerator Do()
		{
			yield return new WaitForSeconds(.3f);
			Create();

			stickManager.Create();
		}

		StartCoroutine(Do());
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			NextLevel();
		}
	}
}