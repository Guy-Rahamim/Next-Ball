using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheatCodeManager : MonoBehaviour
{
	[SerializeField] Button pongButton;
	[SerializeField] AudioClip cheatSound;
	AudioSource audioSource;
	
	//CHEAT CODES!
	int autoPlayIndex = 0;
	int pongIndex = 0;
	KeyCode[] autoPlayCheat = { KeyCode.Alpha3, KeyCode.Period, KeyCode.Alpha1, KeyCode.Alpha4 };
	KeyCode[] pongCheat =	  { KeyCode.P, KeyCode.O, KeyCode.N, KeyCode.G };

	bool autoPlayActivated;
	bool pongActivated;


	// Start is called before the first frame update
	void Start()
    {
		audioSource = GetComponent<AudioSource>();
		autoPlayActivated = false;
		pongActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (!autoPlayActivated)
		{

			if (CheckForAutoPlayCheat())
			{
				audioSource.PlayOneShot(cheatSound);
				autoPlayActivated = true;
				FindObjectOfType<Paddle>().setAutoPlay(true);
			}

		}
		if (!pongActivated)
		{
			if (checkForPongCheat())
			{
				if (SceneManager.GetActiveScene().name == "menu")
				{
					pongActivated = true;
					audioSource.PlayOneShot(cheatSound);
					pongButton.gameObject.SetActive(true);
				}

			}
		}
	}

	public bool CheckForAutoPlayCheat()
	{
		if (Input.anyKeyDown)
			if (Input.GetKeyDown(autoPlayCheat[autoPlayIndex]))
			{
				autoPlayIndex++;
			}
			else
			{
				autoPlayIndex = 0;
			}

		if (autoPlayIndex == autoPlayCheat.Length)
			return true;
		return false;

	}

	public bool checkForPongCheat()
	{
		if (Input.anyKeyDown)
		{
			if (Input.GetKeyDown(pongCheat[pongIndex]))
				pongIndex++;
			else
				pongIndex = 0;
		}
		if (pongIndex == pongCheat.Length)
			return true;
		return false;
	}
}
