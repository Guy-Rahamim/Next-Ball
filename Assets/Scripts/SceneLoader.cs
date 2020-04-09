using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
	
    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void onStartClick()
	{

		SceneManager.LoadScene("Level 1");
	}
	 
	public void onMainMenuButtonClick()
	{
		SceneManager.LoadScene("menu");
	}

	public void onTryAgainClick()
	{
		FindObjectOfType<GameStatus>().resetGame();
		SceneManager.LoadScene("menu");
	}

	public void loadNextLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void loadPong()
	{
		SceneManager.LoadScene("Pong");
	}

	public void onHowToPlayClick()
	{
		SceneManager.LoadScene("How To Play");
	}

	public void loadPongWinScreen()
	{
		SceneManager.LoadScene("Pong Win Screen");
	}

	public void loadPongMenu()
	{
		SceneManager.LoadScene("Pong Menu");
	}


}
