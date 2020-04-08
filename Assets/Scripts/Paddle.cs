using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
	[SerializeField] float screenWidthInUnits = 16f;
	[SerializeField] float min = 1;
	[SerializeField] float max = 15;
	[SerializeField] float shrinkRate = 0.05f;
	[SerializeField] bool AutoPlay = false;
	float controllerX;
    // Start is called before the first frame update
    void Start()
    {
        
    }
	public bool getAutoPlay()
	{
		return AutoPlay;
	}
	public void setAutoPlay(bool value)
	{
			AutoPlay = value;
	}
    // Update is called once per frame
    void Update()
    {
		setController();
		transform.position = new Vector2(Mathf.Clamp(controllerX,min,max), transform.position.y);
    }

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (transform.localScale.x>0.7)
		transform.localScale -= new Vector3(shrinkRate, 0, 0);
	}

	public void setController()
	{
		if (AutoPlay)
			controllerX = FindObjectOfType<Ball>().transform.position.x;// / Screen.width * screenWidthInUnits;
		else
			controllerX = Input.mousePosition.x / Screen.width * screenWidthInUnits;
	}
}
