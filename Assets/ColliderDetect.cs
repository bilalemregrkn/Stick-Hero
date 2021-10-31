using UnityEngine;

public class ColliderDetect : MonoBehaviour
{
	public bool LevelPass;
	[SerializeField] private Transform parent;

	public void LevelController(Vector3 position)
	{
		LevelPass = false;
		parent.position = position;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Pillar"))
		{
			LevelPass = true;
		}
	}
}