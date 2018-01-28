using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour
{
    public AudioClip doorSound;
    public AudioSource audioSource;
    public bool isInteracting = false;
    public Terminal terminal;
	Camera camera;
	public float sightConeRadius;
    public Level_Journal journal;
	public GameObject canvas;
	Descriptor reminderText;
    public GameObject terminalSpot;
    

    
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
        if (!journal) {
            //Debug.LogError("Journal not found");
            journal = GameObject.Find("JournalPREFAB").GetComponent<Level_Journal>();

        }

		GameObject canvas = GameObject.Find("Reminder Text");
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
            GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;
         
        }
        else if(isInteracting==true &&Input.GetKeyDown(KeyCode.Tab))
        {
            isInteracting = false;
            terminal.isInteracting = false;
            GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = true;
        }
        if((gameObject.transform.position-terminalSpot.transform.position).magnitude<=5f && Input.GetKeyDown(KeyCode.E) && isInteracting == false) 
        {
            terminal.isInteracting = true;
            terminal.canvas.SetActive(terminal.isInteracting);
        }
        else if (isInteracting==true && Input.GetKeyDown(KeyCode.Escape))
        {
            terminal.isInteracting = false;
            isInteracting = false;
            terminal.canvas.SetActive(terminal.isInteracting);
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
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="doorAound")
        {
            audioSource.Play();
            audioSource.Stop();
        }
    }

    private void OnTriggerStay(Collider other)
    {
		if (other.tag == "Interactable")
		{
			Debug.Log("There is an interactable nearby.");
			InteractableObject interact = other.GetComponent<InteractableObject>();
			if (interact)
			{
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
						int numInList = interact.giveStats().numberInList;
                        print("adding to journal: " + numInList);
                        journal.addClue(numInList);
                        


					}
				}
				else
				{
					reminderText.FadeOut();
					interact.Unhighlight();
				}
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
