using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public bool isInteracting = false;
    public Terminal terminal;
	// Use this for initialization
	void Start () {
		
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

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("Something entered my collider");
		if(other.tag == "Interactable")
		{
			Debug.Log("It was an interactible object");
			InteractableObject interactible = other.GetComponent<InteractableObject>();
			if (interactible)
			{
				Debug.Log("Highlighting the object");
				interactible.Highlight();
			}
		}
	}

	private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Interactable")
        { 
            InteractableObject interact = other.GetComponent<InteractableObject>(); 
            if((gameObject.transform.position - other.gameObject.transform.position).magnitude <= interact.seeDistance)
            {
                Debug.Log(interact.giveStats());
            }
        }
        else if(other.tag == "terminal")
        {
            terminal = other.GetComponent<Terminal>();
            if ((gameObject.transform.position - other.gameObject.transform.position).magnitude <= terminal.seeDistance && Input.GetKeyDown(KeyCode.E))
            {
                isInteracting = true;
                terminal.isInteracting = true;
                terminal.InteractWith();
                Debug.Log(terminal.tag);
            }
        }
    }

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Interactable")
		{
			InteractableObject interactible = other.GetComponent<InteractableObject>();
			if (interactible)
			{
				interactible.Unhighlight();
			}
		}
	}
}
