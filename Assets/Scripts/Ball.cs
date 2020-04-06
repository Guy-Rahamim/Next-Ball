using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	[SerializeField] Paddle paddle;
	[SerializeField] Vector2 initialForce;
	Vector2 ballToPaddleVector;
	Vector2 paddleLocation;

	bool hasStarted;
    // Start is called before the first frame update
    void Start()
    {
		hasStarted = false;
		ballToPaddleVector = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
	{
		if (!hasStarted)
		{
			stickToPaddle();
		launchOnMouseClick();
		}

			
	}

	private void stickToPaddle()
	{
		paddleLocation = paddle.transform.position;
		transform.position = paddleLocation + ballToPaddleVector;
	}

	private void launchOnMouseClick()
	{

		if (Input.GetMouseButtonDown(0))
		{
			hasStarted = true;
			GetComponent<Rigidbody2D>().velocity=new Vector2(3,10);
		}
	}
}
