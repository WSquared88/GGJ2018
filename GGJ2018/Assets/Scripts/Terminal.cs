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
        
        Status();
    }
    public void Status()
    {
        if (isReceiving == true)
        {
            Debug.Log("Receiving");
            isReceiving = false;
        }
        else
        {
            Debug.Log("Need Reply");

        }
    }
    public bool PlayState()
    {
        return isReceiving;
    }

    public void Menu()
    {
        //calls eventual function for menu pop-up
    }

   
}
