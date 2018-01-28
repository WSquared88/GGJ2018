using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//first data spot in list is always clue, second is always flavor text
public struct Info
{
    public string clueName;
    public string flavorText;
	public string tagName;
    //weakness or strength
   // public string clueType;
}
public class InteractableObject : MonoBehaviour
{
    public int addToJournalDistance;
    public string clueText = "";
    public string flavorText = "";
    public string tagName = "";
	Renderer objectRenderer;
	Renderer[] childrenRenderers;
	public Material normalMaterial;
	public Material outlineMaterial;
	bool highlighted = false;

	// Use this for initialization
	void Start ()
	{
		objectRenderer = GetComponent<Renderer>();
		childrenRenderers = GetComponentsInChildren<Renderer>();
		objectRenderer.material = normalMaterial;

		for (int i = 0; i < childrenRenderers.Length; i++)
		{
			childrenRenderers[i].material = normalMaterial;
		}

        gameObject.tag = "Interactable";

		if(addToJournalDistance <= 0)
		{
			addToJournalDistance = 5;
			Debug.LogError("The sight distance wasn't set. Setting it to " + addToJournalDistance);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

    
    public Info giveStats()
    {
		Debug.Log("The name is " + clueText);
        Info info = new Info()
        {
            clueName = clueText,
            flavorText = flavorText,
			tagName = tagName,
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
		if (!highlighted)
		{
			Debug.Log("Highlighting");
			objectRenderer.material = outlineMaterial;

			for (int i = 0; i < childrenRenderers.Length; i++)
			{
				Debug.Log("Setting a children render on");
				childrenRenderers[i].material = outlineMaterial;
			}

			highlighted = true;
		}
	}

	public void Unhighlight()
	{
		if (highlighted)
		{
			Debug.Log("Unhighlighting");
			objectRenderer.material = normalMaterial;

			for (int i = 0; i < childrenRenderers.Length; i++)
			{
				childrenRenderers[i].material = normalMaterial;
			}

			highlighted = false;
		}
	}
}
