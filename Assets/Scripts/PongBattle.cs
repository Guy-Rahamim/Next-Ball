using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PongBattle : MonoBehaviour
{
	[SerializeField] float maxTime = 60;
	[SerializeField] float timeLeft;
	[SerializeField] TextMeshProUGUI time;

    void Update()
    {
		updateAndDisplayTime();
		if (winCondition())
			FindObjectOfType<SceneLoader>().loadPongWinScreen();
    }

	public bool winCondition()
	{
		if (timeLeft <= 0)
			return true;
		return false;
	}

	public void updateAndDisplayTime()
	{
		timeLeft = maxTime - Time.timeSinceLevelLoad;
		time.text = "Time remaining: " + timeLeft;
	}
}
