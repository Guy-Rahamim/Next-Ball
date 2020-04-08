using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreText : MonoBehaviour
{
	TextMeshProUGUI scoreText;
	GameStatus gameStatus;
    // Start is called before the first frame update
    void Start()
    {
		scoreText = FindObjectOfType<TextMeshProUGUI>();
		Debug.Log(scoreText);
		gameStatus = FindObjectOfType<GameStatus>();
    }

    // Update is called once per frame
    void Update()
    {
		//scoreText.text = gameStatus.getScore().ToString();
    }
}
