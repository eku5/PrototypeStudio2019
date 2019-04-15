using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginGame : MonoBehaviour {

	//public AudioClip sound;
	//AudioSource audioSource;

// Use this for initialization
	void Start () {
	//audioSource = GetComponent<AudioSource>();
	}
	
// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyUp(KeyCode.RightArrow))
		{
		//audioSource.PlayOneShot(sound, .7f);
		Invoke("NextScene", 2);
		}
	}
	
	void NextScene()
	{
		SceneManager.LoadScene(1);
	}
}
