using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	SceneLoader sceneLoader;
	[SerializeField] int remainingBlocks; //for debugging purposes

	public void Start()
	{
		sceneLoader = FindObjectOfType<SceneLoader>();
	}
	public void countBreakableBlocks()
	{
		remainingBlocks++;
	}

	public void blockBroken()
	{
		remainingBlocks--;
		if (remainingBlocks == 0)
			sceneLoader.loadNextLevel();
	}
}
