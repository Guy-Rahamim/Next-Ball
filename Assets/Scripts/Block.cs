using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Block : MonoBehaviour
{
	[SerializeField] AudioClip brokenBlock;
	LevelManager levelManager;

	public void Start()
	{
		levelManager= FindObjectOfType<LevelManager>();
		levelManager.countBreakableBlocks();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		destroyBlock();
	}

	private void destroyBlock()
	{
		levelManager.blockBroken();
		AudioSource.PlayClipAtPoint(brokenBlock, Camera.main.transform.position);
		Destroy(gameObject);
	}
}
