using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameStatus : MonoBehaviour
{


	[Range(0.1f,25f)] [SerializeField] float gameSpeed= 1f;
	[SerializeField] bool AutoPlay = false;
	[SerializeField] TextMeshProUGUI scoreText;
	[SerializeField] int pointsPerBlock = 17;
	[SerializeField] int totalScore = 0;

	public bool getAutoPlay()
	{
		return AutoPlay;
	}
	
    // Start is called before the first frame update
    void Start()
    {

	}

	private void Awake()
	{
		gameSpeed = 1f;
		int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
		if (gameStatusCount > 1)
		{
			gameObject.SetActive(false);
			Destroy(gameObject);
		}
		else
			DontDestroyOnLoad(gameObject);
	}


	// Update is called once per frame
	void Update()
    {
		controlSpeed();
		Time.timeScale = Mathf.Clamp(gameSpeed,0.2f,10);
		updateScore();

	}

	void controlSpeed()
	{
		if (Input.anyKeyDown)
		{
			if (Input.GetKey(KeyCode.Equals))
				gameSpeed += 0.2f;
			if (Input.GetKeyDown(KeyCode.Minus))
				gameSpeed -= 0.2f;
		}
	}

	public void addScore()
	{
		totalScore += pointsPerBlock;
	}

	public void updateScore()
	{
		scoreText.text = totalScore.ToString();
	}

	public void resetGame()
	{
		Destroy(gameObject);
	}


}
