using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Journal:MonoBehaviour{

    int clueCount;
    int foundCount;
    int tabCount;

    List <Clue> clueList = new List<Clue>();
    List<Clue> foundClues = new List<Clue>();

    bool isSolved;

    List<Tab> tabList = new List<Tab>();

    Clue tempClue;
    public Clue clue;

    public Tab tab1;
    public Tab tab2;
    public Tab tab3;


	// Use this for initialization
	void Start () {
        clueCount = 0;
        foundCount = 0;
        tabCount = 0;

        createTabs();

       

        isSolved = false;


        GameObject.Find("Tab1_grey").SetActive(false);
        GameObject.Find("Tab2_grey").SetActive(true);
        GameObject.Find("Tab3_grey").SetActive(true);

        GameObject.Find("Tab2_BG").SetActive(false);
        GameObject.Find("Tab3_BG").SetActive(false);

        tab1.isDisplayed = true;

        addClue(5);
        addClue(3);
        addClue(16);
        addClue(8);
        addClue(13);
        addClue(20);

        discoverClue(3);
        discoverClue(5);
        discoverClue(16);
        //discoverClue(8);
        //discoverClue(13);
        //discoverClue(20);
        tab1.fillScreen();
    }


    //get the number of clues for the level
    public int getClueCount() {
        return clueCount;

    }


    //adds clue to the List of clues; instantiated at begining of level
    public void addClue(int clueNum) {

        clueList.Add(Instantiate(clue));
        clueList[clueCount].setClueNum(clueNum);
        clueCount++;
    }


    //level has been solved
    public void levelSolved() {

        isSolved = true;

    }

    //get isSolved
    public bool getIsSolved() {
        return isSolved;

    }

    //creates tabs
    public void createTabs() {
        tabList.Add(Instantiate(tab1));
        tabList.Add(Instantiate(tab2));
        tabList.Add(Instantiate(tab3));

        tab1.setTabOBJs(GameObject.Find("Tab1_obj"), GameObject.Find("Tab1_BG"));
        tab2.setTabOBJs(GameObject.Find("Tab2_obj"), GameObject.Find("Tab2_BG"));
        tab3.setTabOBJs(GameObject.Find("Tab3_obj"), GameObject.Find("Tab3_BG"));

        //tab1.toggleDisplayed();
    }

    //item is found, increase foundCount
    public void increaseFoundCount(int clueNum) {
        

        

        for (int i = 0; i < clueCount; i++) {

            if (clueList[i].getClueNum() == clueNum)
            {

               tempClue = clueList[i];
            }

        }

            if (foundCount <= 5){
            if (foundCount == 0) {
                tabList[tabCount].setClue1(tempClue);

                foundCount++;
            }
            else if (foundCount % 2 != 0)
            {

                tabList[tabCount].setClue2(tempClue);
                foundCount++;
            }
            else
            {
                tabCount++;
                tabList[tabCount].setClue1(tempClue);
                foundCount++;
                if (tabCount == 1)
                {

                    GameObject.Find("Tab2_grey").SetActive(false);
                    tabList[tabCount].setTabOBJs(GameObject.Find("Tab2_obj"), GameObject.Find("Tab2_BG"));


                }
                else if (tabCount == 2)
                {

                    GameObject.Find("Tab3_grey").SetActive(false);
                    tabList[tabCount].setTabOBJs(GameObject.Find("Tab3_obj"), GameObject.Find("Tab3_BG"));


                }
            }
            }
    
    }

    //discovered clue
    public void discoverClue(int clueNum) {
        increaseFoundCount(clueNum);

    }


    // Update is called once per frame
    void Update () {
		
	}
}
