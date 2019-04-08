using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Choices : MonoBehaviour
{
	public KeyCode key;
	private Button _button;
	public float selectionTime; // this is for how long players should press/hold to confirm a choice
	public float pressTime;

	private bool canPress;
	private Transform progressBar;
	private RectTransform rt;
	
	public Color color = Color.white;

	void Start()
	{
		color.a = 0f;
	}
	
	
	void Awake()
	{
		_button = GetComponent<Button>();
		rt = GetComponent<RectTransform>();
		
		//the progress bar is the second child of the button. The first child is the text.
		progressBar = transform.GetChild(1);
	}
	
	// Update is called once per frame
	void Update () {
		ProgressPosition();

		ProgressLength();
		
		//make sure they can't just hold down the key from button to button
		if (Input.GetKeyDown(key))
		{
			canPress = true;
		}
		
		//press and hold the key to select
		if (Input.GetKey(key) && canPress)
		{
			_button.interactable = true;
			//change the text and background color when the key is being pressed
			_button.image.color = Color.black;
			_button.GetComponentInChildren<TextMeshProUGUI>().color = color;
			
			//increase the amount of "presstime" as long as the button is held
			pressTime += Time.deltaTime;
			
			//if the button has been pressed long enough, act like the button has been clicked
			if (pressTime >= selectionTime)
			{
				_button.onClick.Invoke();
			}
		}
		else
		{
			//if the button isn't being pressed, reset the visual state and reset the "presstime"
			_button.image.color = Color.white;
			_button.GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
			pressTime = 0;
			_button.interactable = false;
		}
	}

	void ProgressPosition()
	{
		progressBar.localPosition = new Vector3(-rt.rect.width / 2, -rt.rect.height/3f, -1);
	}

	void ProgressLength()
	{
		progressBar.localScale = new Vector3( pressTime * rt.rect.width, 5, 1);
	}
}
