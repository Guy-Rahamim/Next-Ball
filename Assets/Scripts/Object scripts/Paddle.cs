using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
	//[SerializeField] float screenWidthInUnits = 12f;
	[SerializeField] float min = 1;
	[SerializeField] float max = 15;
	[SerializeField] float shrinkRate = 0.05f;
	[SerializeField] bool AutoPlay = false;
	float controllerX;


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


	public void setController()
	{
		if (AutoPlay)
			controllerX = FindObjectOfType<Ball>().transform.position.x;
		else
			controllerX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;

	}
}
