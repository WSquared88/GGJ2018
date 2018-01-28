using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour
{
    public bool isInteracting = false;
    public Terminal terminal;
	Camera camera;
	public float sightConeRadius;
	public GameObject canvas;
	Descriptor reminderText;
	// Use this for initialization
	void Start ()
	{
		camera = GetComponent<Camera>();
		if (!camera)
		{
			Debug.LogError("There is no camera here!");
		}

		if (sightConeRadius <= 0)
		{
			sightConeRadius = 35;
			Debug.LogError("The sight line isn't set correctly. Setting to " + sightConeRadius);
		}

		//GameObject canvas = GameObject.Find("Reminder Text");
		if (canvas)
		{
			reminderText = canvas.GetComponent<Descriptor>();
		}
		else
		{
			Debug.LogError("The reminder text canvas isn't here!");
		}

		if(!reminderText)
		{
			Debug.LogError("The description canvas isn't attached!");
		}
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isInteracting == true)
        {
            //freeze character movement
            gameObject.GetComponent<FirstPersonController>().enabled = false;
            
        }
        else if(isInteracting==true && Input.GetKeyDown(KeyCode.Escape))
        {
            isInteracting = false;
            terminal.isInteracting = false;
            gameObject.GetComponent<FirstPersonController>().enabled = true;
        }
	}

	bool CanSeeInteractable(InteractableObject interactable, Collider interactableCollider)
	{
		Vector3 playerToObject = interactable.transform.position - transform.position;
		float dot = Vector3.Dot(playerToObject.normalized, camera.transform.forward);
		float degreesAwayFromForward = Mathf.Acos(dot) * Mathf.Rad2Deg;
		//Debug.Log("The interactable is close, but is it in front of me?");

		if (degreesAwayFromForward <= sightConeRadius * 2)
		{
			Debug.Log("The object is in front of the player, but is something in the way?");
			RaycastHit hit;
			Physics.Raycast(camera.transform.position, playerToObject, out hit);
			return hit.collider == interactableCollider;
		}

		return false;
	}

	private void OnTriggerEnter(Collider other)
	{

	}

	private void OnTriggerStay(Collider other)
    {
		if (other.tag == "Interactable")
		{
			Debug.Log("There is an interactable nearby.");
			InteractableObject interact = other.GetComponent<InteractableObject>();
			if (CanSeeInteractable(interact, other))
			{
				interact.Highlight();
				Vector3 playerToObject = interact.transform.position - transform.position;
				if (playerToObject.magnitude <= interact.addToJournalDistance)
				{
					Debug.Log("The interactable is close enough to add to our journal.");
					Info itemInfo = interact.giveStats();
					Debug.Log(itemInfo);
					reminderText.SetText(itemInfo.tagName);
					reminderText.SetPosition(interact.transform.position);
					reminderText.FadeIn();
				}
			}
			else
			{
				reminderText.FadeOut();
				interact.Unhighlight();
			}
		}
		else if (other.tag == "Terminal")
		{
			Terminal terminal = other.GetComponent<Terminal>();
			if (CanSeeInteractable(terminal, other) && Input.GetKeyDown(KeyCode.E))
			{
				isInteracting = true;
				Debug.Log(terminal.tag);
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Interactable")
		{
			InteractableObject interactable = other.GetComponent<InteractableObject>();
			if (interactable)
			{
				interactable.Unhighlight();
				reminderText.FadeOut();
			}
		}
	}
}
