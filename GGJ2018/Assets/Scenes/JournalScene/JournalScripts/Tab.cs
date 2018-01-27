using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tab : MonoBehaviour {

    bool isDisplayed;

    Clue clue1;
    Clue clue2;

	// Use this for initialization
	void Start () {
		
	}


    //toggles whether or not the tab and its clues are displayed or not
    public void toggleDisplayed() {

        isDisplayed = !isDisplayed;

    }

    //returns whether or not the tab is displayed
    public bool getIsDisplayed() {

        return isDisplayed;

    }


    //set clue1
    public void setClue1(Clue sentClue) {

        clue1 = sentClue;

    }

   //set clue2
   public void setClue2(Clue sentClue){

        clue2 = sentClue;

    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
