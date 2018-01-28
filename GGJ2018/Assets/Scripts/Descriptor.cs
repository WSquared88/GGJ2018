using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Descriptor : MonoBehaviour
{
	public float verticalOffset;
	string title;
	Animator animator;
	bool visible;
	Text text;

	// Use this for initialization
	void Start ()
	{
		//FadeOut();
		animator = GetComponent<Animator>();
		visible = false;
		text = GetComponentInChildren<Text>();

		if(!text)
		{
			Debug.LogError("The text couldn't be found on the descriptor");
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void SetText(string newText)
	{
		text.text = newText;
	}

	public void FadeIn()
	{
		if (!visible)
		{
			animator.SetTrigger("FadeIn");
			visible = true;
		}
		//gameObject.SetActive(true);
	}

	public void FadeOut()
	{
		if (visible)
		{
			animator.SetTrigger("FadeOut");
			visible = false;
		}
		//gameObject.SetActive(false);
	}

	public void SetPosition(Vector3 position)
	{
		transform.position = new Vector3(position.x, position.y + verticalOffset, position.z);
	}
}
