using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoseCollider : MonoBehaviour
{
	GameStatus gameStatus;
	SceneLoader sceneLoader;
	Ball ball;
	Paddle paddle;
	[SerializeField] Ball prefabBall;
	public void Start()
	{
		paddle = FindObjectOfType<Paddle>();
		gameStatus = FindObjectOfType<GameStatus>();
		sceneLoader = FindObjectOfType<SceneLoader>();
		ball = FindObjectOfType<Ball>();
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		 if (SceneManager.GetActiveScene().name == "Pong")
			SceneManager.LoadScene("Pong Menu");
		else if (gameStatus.getLife() > 1)
		{
			//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			reloadBall();
		}

		else
		SceneManager.LoadScene("Game Over");
	}

	private void reloadBall()
	{
		
		Destroy(ball);
		prefabBall = Instantiate(prefabBall);
		prefabBall.paddle = paddle;
		prefabBall.transform.position = prefabBall.paddle.transform.position + new Vector3(0, 0.5f, 0);
		gameStatus.setLife(gameStatus.getLife() - 1);
	}
}
