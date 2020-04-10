using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameStatus : MonoBehaviour
{

	[SerializeField] int life = 5;
	[Range(0.1f,25f)] [SerializeField] float gameSpeed= 1f;
	[SerializeField] bool AutoPlay = false;
	[SerializeField] TextMeshProUGUI scoreText;
	[SerializeField] TextMeshProUGUI lifeText;
	[SerializeField] int pointsPerBlock = 17;
	[SerializeField] int totalScore = 0;

	public bool getAutoPlay()
	{
		return AutoPlay;
	}
	
    // Start is called before the first frame update
    void Start()
    {
		updateLife();
		updateScore();
		gameSpeed = 1f;
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
		if (SceneManager.GetActiveScene().name.Contains("menu") || SceneManager.GetActiveScene().name.Contains("Menu"))
			Destroy(gameObject);

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
		updateScore();
	}

	public void updateScore()
	{
		scoreText.text ="Score: " + totalScore.ToString();
	}

	public void resetGame()
	{
		Destroy(gameObject);
	}

	public void resetGameSpeed()
	{
		gameSpeed = 1f;
	}

	public int getLife()
	{
		return life;
	}

	public void setLife(int life)
	{
		this.life = life;
		updateLife();
	}

	public void updateLife()
	{
		lifeText.text = "Life remaining: " + getLife() ;
	}
}
