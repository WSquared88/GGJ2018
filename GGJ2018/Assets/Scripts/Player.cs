using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
    }
}
