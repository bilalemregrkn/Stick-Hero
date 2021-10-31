using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }

	[SerializeField] private TextMeshProUGUI textScore;

	private void Awake()
	{
		Instance = this;
		Score = 0;
	}

	public int Score
	{
		get => _score;
		set
		{
			_score = value;
			textScore.SetText(_score.ToString());
		}
	}

	private int _score;
}