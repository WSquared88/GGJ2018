using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Journal : MonoBehaviour {

    int clueCount;
    int foundCount;
    int tabCount;

    List <Clue> clueList = new List<Clue>();
    List<Clue> foundClues = new List<Clue>();

    bool isSolved;

    List<Tab> tabList = new List<Tab>();

    Clue tempClue;


	// Use this for initialization
	void Start () {
        clueCount = 0;
        foundCount = 0;
        tabCount = 0;
        createTabs();
        isSolved = false;

	}


    //get the number of clues for the level
    public int getClueCount() {
        return clueCount;

    }


    //adds clue to the List of clues; instantiated at begining of level
    public void addClue(int clueNum) {

        clueList.Add(new Clue());
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
        tabList.Add(new Tab());


    }

    //item is found, increase foundCount
    public void increaseFoundCount(int clueNum) {
        foundCount++;

        

        for (int i = 0; i < clueCount; i++) {

            if (clueList[i].getClueNum() == clueNum)
            {

               tempClue = clueList[i];
            }

        }

            if (foundCount <= 5){
                if (foundCount % 2 == 0)
                {

                    tabList[tabCount].setClue2(tempClue);
                }
                else
                {
                    createTabs();
                    tabCount++;
                    tabList[tabCount].setClue1(tempClue);
                }
            }
    
    }


    // Update is called once per frame
    void Update () {
		
	}
}
