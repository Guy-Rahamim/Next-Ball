using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	//Configurable Parameters.
	[SerializeField] Paddle paddle;
	[SerializeField] Vector2 initialForce;
	Vector2 ballToPaddleVector;
	Vector2 paddleLocation;
	[SerializeField] AudioClip[] ballSounds;
	[SerializeField] float movementTweak = 0.2f;

	//chached references.
	AudioSource myAudioSource;
	Rigidbody2D myRigidBody;

	bool hasStarted;
    // Start is called before the first frame update
    void Start()
    {
		myAudioSource = GetComponent<AudioSource>();
		myRigidBody = GetComponent<Rigidbody2D>();
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
		myRigidBody.velocity=new Vector2(initialForce.x,initialForce.y);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Vector2 velocityTweak = new Vector2(Random.Range(-movementTweak, movementTweak), Random.Range(-movementTweak, movementTweak));

		if (hasStarted)
		{
			AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length - 1)];
			myRigidBody.velocity += velocityTweak;
			myAudioSource.PlayOneShot(clip);
		}
	}
}
