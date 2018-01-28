using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public Canvas credits;
	public Canvas menu;
	// Use this for initialization
	void Start ()
	{
		if(!credits)
		{
			Debug.LogError("The credits scene isn't attached!");
		}

		if(!menu)
		{
			Debug.LogError("The menu isn't attached!");
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void StartScene(string levelToLoad)
	{
		SceneManager.LoadScene(levelToLoad);
	}

	public void ShowCredits(bool enable)
	{
		credits.gameObject.SetActive(enable);
		menu.gameObject.SetActive(!enable);
	}

	public void Exit()
	{
		Application.Quit();
	}
}
