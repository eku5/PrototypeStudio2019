using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
	private int fadeState; //this is checked in Update, i.e. 0 is idle, -1 is for fadeOut, 1 is for fadeIn
	private float fadeTime;
	private SpriteRenderer sr;

	// Use this for initialization
	void Start ()
	{
		sr = GetComponent<SpriteRenderer>();
		fadeState = 0; //in "idle" as default
	}
	
	// Update is called once per frame
	void Update () {
		if (fadeState == 0)
		{
			return;
		} else if (fadeState == -1) //this is what causes the sprite to fade out
		{
			Color c = sr.color;
			c.a -= 1 / fadeTime * Time.deltaTime; //how much the alpha is changing per frame
			sr.color = c;
			if (sr.color.a <= 0)
				fadeState = 0;
		} else if (fadeState == 1) //this is what causes the sprite to fade in
		{
			Color c = sr.color;
			c.a += 1 / fadeTime * Time.deltaTime; //how much the alpha is changing per frame
			sr.color = c;
			if (sr.color.a >= 1)
				fadeState = 0;
		} 
	}

	public void FadeIn(float time)
	{
		fadeState = 1;
		fadeTime = time;
	}

	public void FadeOut(float time)
	{
		fadeState = -1;
		fadeTime = time;
	}
}

