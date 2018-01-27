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
        }
        else if(isInteracting==true && Input.GetKeyDown(KeyCode.Escape))
        {
            isInteracting = false;
            terminal.isInteracting = false;

        }
	}
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "interactable")
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
}
