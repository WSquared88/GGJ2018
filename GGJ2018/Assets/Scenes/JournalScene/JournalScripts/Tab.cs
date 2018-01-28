using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tab : MonoBehaviour
{

    public bool isDisplayed;

    Clue clue1;
    Clue clue2;

    public bool clue1Valid;
    public bool clue2Valid;

    GameObject tabOBJ;
    GameObject tabBG;

    // Use this for initialization
    void Start()
    {

    }


    //set tabOBJ
    public void setTabOBJs(GameObject sentTabOBJ, GameObject senttabBG)
    {
        tabOBJ = sentTabOBJ;
        tabBG = senttabBG;

    }

    //toggles whether or not the tab and its clues are displayed or not
    public void toggleDisplayed()
    {

        isDisplayed = !isDisplayed;



    }

    //returns whether or not the tab is displayed
    public bool getIsDisplayed()
    {

        return isDisplayed;

    }


    //set clue1
    public void setClue1(Clue sentClue)
    {
        clue1 = sentClue;
        print("clue1 name: " + clue1.getClueName()+" hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");
        clue1Valid = true;

    }

    //set clue2
    public void setClue2(Clue sentClue)
    {

        clue2 = sentClue;
        clue2Valid = true;


    }



    public Clue getClue1()
    {

        return clue1;

    }

    public Clue getClue2()
    {

        return clue2;

    }


    public void fillScreen()
    {

        if (clue1Valid)
        {


            GameObject.Find("Image1").GetComponent<Image>().sprite = clue1.getImage();
            GameObject.Find("Desc1").GetComponent<Text>().text = clue1.getClueDesc();
            GameObject.Find("Title1").GetComponent<Text>().text = clue1.getClueName();

           


        }
        if (clue2Valid)
        {
            GameObject.Find("Image2").GetComponent<Image>().sprite = clue2.getImage();
            GameObject.Find("Desc2").GetComponent<Text>().text = clue2.getClueDesc();
            GameObject.Find("Title2").GetComponent<Text>().text = clue2.getClueName();

        }
        else
        {
            GameObject.Find("Image2").GetComponent<Image>().sprite = null;
            GameObject.Find("Desc2").GetComponent<Text>().text = "";
            GameObject.Find("Title2").GetComponent<Text>().text = "";

        }


    }


    //get clue1
    public Clue returnclue1()
    {

        return clue1;

    }

    // Update is called once per frame
    void Update()
    {

    }
}