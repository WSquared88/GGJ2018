using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tab:MonoBehaviour{

    public bool isDisplayed;

    Clue clue1;
    Clue clue2;

    bool clue1Valid;
    bool clue2Valid;

    GameObject tabOBJ;
    GameObject tabBG;

	// Use this for initialization
	void Start () {
        clue1Valid = false;
        clue2Valid = false;
	}


    //set tabOBJ
    public void setTabOBJs(GameObject sentTabOBJ,GameObject senttabBG) {
        tabOBJ = sentTabOBJ;
        tabBG = senttabBG;

    }

    //toggles whether or not the tab and its clues are displayed or not
    public void toggleDisplayed() {

        isDisplayed = !isDisplayed;


        if (!isDisplayed)
        {

            tabOBJ.SetActive(false);
            tabBG.SetActive(false);

        }
        else
        {

            tabOBJ.SetActive(true);
            tabBG.SetActive(true);

            

        }

    }

    //returns whether or not the tab is displayed
    public bool getIsDisplayed() {

        return isDisplayed;

    }


    //set clue1
    public void setClue1(Clue sentClue) {
        print("Clue1");
        clue1 = sentClue;
        clue1Valid = true;
        fillScreen();
    }

   //set clue2
   public void setClue2(Clue sentClue){

        clue2 = sentClue;
        clue2Valid = true;
        fillScreen();

    }

    public void fillScreen() {

        if (isDisplayed)
        {
            if (clue1Valid)
            {
                print("test");

                //GameObject.Find("Image1").GetComponent<Image>().sprite = 
                GameObject.Find("Desc1").GetComponent<Text>().text = clue1.getClueDesc();
            }
            if (clue2Valid)
            {

            }
        }

    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
