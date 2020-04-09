using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
	//Configurable Parameters.
	[SerializeField] public Paddle paddle;
	[SerializeField] Vector2 initialForce;
	[SerializeField] float minimumYThresholde=2;
	Vector2 ballToPaddleVector;
	Vector2 paddleLocation;
	[SerializeField] AudioClip[] ballSounds;
	[SerializeField] float movementTweak = 0.2f;
	Vector2 velocityTweak;

	//chached references.
	AudioSource myAudioSource;
	Rigidbody2D myRigidBody;

	[SerializeField] bool hasStarted;
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
		if (Input.GetMouseButtonDown(0)||SceneManager.GetActiveScene().name=="Pong")
		{
			hasStarted = true;
		myRigidBody.velocity=new Vector2(Random.Range(-initialForce.x,initialForce.x),initialForce.y);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (hasStarted)
		{
			if (myRigidBody.velocity.x == 0)
				myRigidBody.velocity += new Vector2(movementTweak,0);

			if (myRigidBody.velocity.y == 0)
				myRigidBody.velocity += new Vector2(0, movementTweak);

			AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length - 1)];
			myAudioSource.PlayOneShot(clip);
		}
	}
}
