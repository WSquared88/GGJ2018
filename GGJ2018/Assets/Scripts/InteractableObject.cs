﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//first data spot in list is always clue, second is always flavor text
public struct Info
{
    public string clue;
    public string flavorText;
}
public class InteractableObject : MonoBehaviour
{
    public int seeDistance;
    public string clueText = "";
    public string flavorText = "";
    public string tagName = "";
	Renderer objectRenderer;
	public Material normalMaterial;
	public Material outlineMaterial;

	// Use this for initialization
	void Start ()
	{
		objectRenderer = GetComponent<Renderer>();
		objectRenderer.material = normalMaterial;
        gameObject.tag = tagName;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.H))
		{
			Highlight();
		}

		if(Input.GetKeyUp(KeyCode.H))
		{
			Unhighlight();
		}
	}

    
    public Info giveStats()
    {

        Info info = new Info()
        {
            clue = "vool",
            flavorText = "Im very diabetic",
        };
      
     
        return info;

    }

	public virtual void assignValues(string clue, string flavor)
	{
		clueText = clue;
		flavorText = flavor;
	}

	public void Highlight()
	{
		objectRenderer.material = outlineMaterial;
	}

	public void Unhighlight()
	{
		objectRenderer.material = normalMaterial;
	}
}
