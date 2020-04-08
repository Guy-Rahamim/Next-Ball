using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCodeManager : MonoBehaviour
{
	//CHEAT CODES!
	int autoPlayIndex = 0;
	int pongIndex = 0;
	KeyCode[] autoPlayCheat = { KeyCode.Alpha3, KeyCode.Period, KeyCode.Alpha1, KeyCode.Alpha4 };
	KeyCode[] pongCheat =	  { KeyCode.P, KeyCode.O, KeyCode.N, KeyCode.G };


	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (CheckForAutoPlayCheat())
			FindObjectOfType<Paddle>().setAutoPlay(true);
		
		if(checkForPongCheat())
		{
			//FindObjectOfType<SceneLoader>().loadPong();
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
