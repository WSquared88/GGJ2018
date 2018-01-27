using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : InteractableObject {
    private bool isReceiving;
    public bool isInteracting;
	// Use this for initialization
	void Start () {
        tagName = "terminal";
        isReceiving = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void InteractWith()
    {
        if (isInteracting == true)
        {
            Status();
            isInteracting = false;
        }
        
    }
    public void Status()
    {
        if (isReceiving == true)
        {
            Debug.Log("Receiving");
            //call functions involving bringing the UI up
            isReceiving = false;
        }
        else
        {
            Debug.Log("Need Reply");

        }
    }
    //function to return the playstate of the terminal
    public bool PlayState()
    {

        return isInteracting;
    }

    public void Menu()
    {
        //calls eventual function for menu pop-up
    }

   
}
