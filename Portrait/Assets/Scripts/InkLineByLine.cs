using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

public class InkLineByLine : MonoBehaviour {
	
[SerializeField]
	private TextAsset _inkJSONAsset;
	private Story _story;

	[SerializeField]
	private Canvas canvas;

	// UI Prefabs
	[SerializeField]
	private GameObject textPrefab;
	[SerializeField]
	private Button buttonPrefab;
	
	public List<string> storyTags;
    //public ChangeBackground BGController;
	//public ChangeSound SoundController;
	//public int dissociationValue;
	//public int bgIndex;
	public float sceneChangeTime, typeSpeed; //this is for how long the wait is before we change scenes.

	private bool _activeChoices, _activelyTyping;

	void Start () {
		_story = new Story(_inkJSONAsset.text);
		_activeChoices = false;
		_activelyTyping = false;
		
		//_story.ObserveVariable ("dissociation", (string varName, object newValue) => {
		//	dissociationValue = (int)newValue;
		//});
		/*_story.ObserveVariable ("soundIndex", (string varName, object newValue) => {
			bgIndex = (int)newValue;
		});*/

		ShowNextLine();
	}
	
	void Update ()
	{
		if (Input.anyKeyDown)
		{
			if (_story.currentChoices.Count > 0 && !_activeChoices  && !_activelyTyping)
			{
				DisplayChoices();
			} else if (_story.currentChoices.Count == 0 && _story.canContinue && !_activelyTyping)
			{
				ClearCanvas();
				ShowNextLine();	
			}
		}

		if (!_activeChoices)
		{
			Debug.Log("No choices here");
		}
		else
		{
			Debug.Log("# of active choices: " + _story.currentChoices.Count);
		}
		
		if (_story.currentChoices.Count == 0 && !_story.canContinue)
		{
			Invoke("NextScene", sceneChangeTime);
		}

	}

	void ShowNextLine () {
		if (_story.canContinue)
		{
			var text = _story.Continue();
			text = text.Trim();
			
			if (text != "")
			{
				GameObject panel = Instantiate(textPrefab);
				panel.transform.SetParent(canvas.transform, false);

				TextMeshProUGUI storyText = panel.GetComponentInChildren<TextMeshProUGUI>();
				storyText.text = "";

				if (_story.currentTags.Contains("appear"))
				{
					//make the text appear all at once if the story tag has the word "appear"
					storyText.text = text;
				}
				else
				{
					//otherwise make it all type out slowly,
					//make the player wait for the full text to be typed before the story can move forward..
					StartCoroutine(PlayText(storyText, text));
				}

				storyTags = _story.currentTags;
				//BGController.backgroundIndex = bgIndex;

				if (storyTags.Contains("title"))
				{
					storyText.fontSize = 60;
					storyText.fontStyle = FontStyles.Bold;
				}

				if (storyTags.Contains("subtitle"))
				{
					storyText.fontSize = 50;
				}
			}
		}
	}
	IEnumerator PlayText(TextMeshProUGUI tmp, string text)
	{
		_activelyTyping = true;
		foreach (char c in text) 
		{
			tmp.text += c;
			
			if (tmp.text.Length == text.ToCharArray().Length)
			{
				_activelyTyping = false;
			}
			yield return new WaitForSeconds (typeSpeed);
		}
	}
	
	//CHOICES!
	void DisplayChoices()
	{
		_activeChoices = true;
			for (int i = 0; i < _story.currentChoices.Count; i++) {
				Choice choice = _story.currentChoices [i];
				Button button = CreateButton(choice.text.Trim ());
				// Tell the button what to do when we press it
				button.onClick.AddListener (delegate {
					OnClickChoiceButton (choice);
				});

				Vector2 upPos, leftPos, rightPos;
				
				if (storyTags.Contains("fullpage"))
				{
					upPos = new Vector2(0,-420);
					leftPos = new Vector2(-500,-480);
					rightPos = new Vector2(500,-480);
				} else
				{
					upPos = new Vector2(0,-100);
					leftPos = new Vector2(-500,-180);
					rightPos = new Vector2(500,-180);	
				}

				// Assign button inputs depending on how many choices are available.
				// This was for Under Oath below.
				/*
				if (_story.currentChoices.Count == 1)
				{
					SetButtonForChoice(button, KeyCode.UpArrow);
					SetButtonPosition(button, upPos.x,upPos.y);
				} 
				else if (_story.currentChoices.Count == 2)
				{
					if (i == 0)
					{
						SetButtonForChoice(button, KeyCode.LeftArrow);
						SetButtonPosition(button, leftPos.x,leftPos.y);

					} else if (i == 1)
					{
						SetButtonForChoice(button, KeyCode.RightArrow);
						SetButtonPosition(button, rightPos.x,rightPos.y);

					}
				} else if (_story.currentChoices.Count == 3)
				{
					if (i == 0)
					{
						SetButtonForChoice(button, KeyCode.LeftArrow);
						SetButtonPosition(button, leftPos.x,leftPos.y);

					} else if (i == 1)
					{
						SetButtonForChoice(button, KeyCode.UpArrow);
						SetButtonPosition(button,upPos.x,upPos.y);

					} else if (i == 2)
					{
						SetButtonForChoice(button, KeyCode.RightArrow);
						SetButtonPosition(button, rightPos.x,rightPos.y);
					}
				}*/
				
				// My own attempt at customizing the button input stuff...
				if (_story.currentChoices.Count == 1)
				{
					SetButtonForChoice(button, KeyCode.Mouse0);
					SetButtonPosition(button, upPos.x,upPos.y);
				} 
				
			}
	}
	void OnClickChoiceButton (Choice choice) {
		_story.ChooseChoiceIndex (choice.index);
		_activeChoices = false;
		ClearCanvas();
		ShowNextLine();
	}
	// Creates a button showing the choice text
	Button CreateButton (string text) {
		// Creates the button from a prefab
		Button choice = Instantiate (buttonPrefab);
		choice.transform.SetParent (canvas.transform, false);
		
		// Gets the text from the button prefab
		TextMeshProUGUI choiceText = choice.GetComponentInChildren<TextMeshProUGUI> ();
		choiceText.text = text;

		// Make the button expand to fit the text
		HorizontalLayoutGroup layoutGroup = choice.GetComponent <HorizontalLayoutGroup> ();
		layoutGroup.childForceExpandHeight = false;

		return choice;
	}
	// Custom-made script to allow us to decide which button we want the player to hold in order to select an option.
	void SetButtonForChoice(Button btn, KeyCode key)
	{
		Choices buttonChoice = btn.GetComponent<Choices>();
		buttonChoice.key = key;
	}

	void SetButtonPosition(Button button, float xPos, float yPos)
	{
		button.GetComponent<RectTransform>().localPosition= new Vector3(xPos, yPos, 0);
	}
	void ClearCanvas()
	{
		int childCount = canvas.transform.childCount;
		for (int i = childCount - 1; i >= 0; --i) {
			Destroy (canvas.transform.GetChild (i).gameObject);
		}
	}
	//SceneManager!
	void NextScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
