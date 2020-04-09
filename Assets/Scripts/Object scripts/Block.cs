using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Block : MonoBehaviour
{
	//Configuration Parameters.
	[SerializeField] GameObject blockSparklesVFX;
	[SerializeField] AudioClip brokenBlock;
	[SerializeField] Sprite[] blockSprites;
	

	//Cached references.
	LevelManager levelManager;
	GameStatus gameStatus;

	//State variables.
	int maxHits;
	int timesHit;

	public void Start()
	{
		//initialize state variables
		timesHit = 0;

		gameStatus = FindObjectOfType<GameStatus>();
		levelManager= FindObjectOfType<LevelManager>();
		if(tag=="Breakable")
		levelManager.countBreakableBlocks();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		 if (tag=="Breakable")
		{
			maxHits = blockSprites.Length;
			timesHit++;
			if (timesHit >= maxHits)
				destroyBlock();
			else
				GetComponent<SpriteRenderer>().sprite = blockSprites[timesHit];
		}

	}

	private void destroyBlock()
	{
		gameStatus.addScore();
		levelManager.blockBroken();
		AudioSource.PlayClipAtPoint(brokenBlock, Camera.main.transform.position);
		triggerSparkles();
		Destroy(gameObject);
	}

	private void triggerSparkles()
	{
		GameObject sparkles = Instantiate(blockSparklesVFX,transform.position,transform.rotation);
		Destroy(sparkles, 2f);
	}
}
