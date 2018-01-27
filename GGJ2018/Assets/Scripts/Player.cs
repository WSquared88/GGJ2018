using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public bool isInteracting = false;
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
	}
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "interactable")
        { 
            InteractableObject interact = other.GetComponent<InteractableObject>(); 
            if((gameObject.transform.position - other.gameObject.transform.position).magnitude <= interact.seeDistance)
            {
                Debug.Log(interact.giveStats()[1]);
            }
        }
        else if(other.tag == "terminal")
        {
            Terminal terminal = other.GetComponent<Terminal>();
            if ((gameObject.transform.position - other.gameObject.transform.position).magnitude <= terminal.seeDistance && Input.GetKeyDown(KeyCode.E))
            {
                isInteracting = true;
                Debug.Log(terminal.tag);
            }
        }
    }
}
