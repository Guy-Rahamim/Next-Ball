using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
	[SerializeField] float screenWidthInUnits = 16f;
	[SerializeField] float min = 1;
	[SerializeField] float max = 15;
	Vector2 mousePos;
	float mouseX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		mouseX = Input.mousePosition.x / Screen.width * screenWidthInUnits;
		transform.position = new Vector2(Mathf.Clamp(mouseX,min,max), transform.position.y);
    }
}
