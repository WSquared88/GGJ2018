using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_Journal : MonoBehaviour
{

    public int clueCount;
    int foundCount;
    int tabCount;

    public List<Clue> clueList = new List<Clue>();
    List<int> foundClues = new List<int>();

    bool isSolved;

    List<Tab> tabList = new List<Tab>();

    Clue tempClue;
    public Clue clue;

    Tab tab1;
    Tab tab2;
    Tab tab3;


    public Sprite bgImg1;
    public Sprite bgImg2;
    public Sprite bgImg3;

    Button tab1_button;
    Button tab2_button;
    Button tab3_button;

    public Journal theJournal;

    int waitingCount;



    // Use this for initialization
    void Start()
    {

        if (!theJournal) {
            Debug.LogError("Journal not found");
            theJournal = GameObject.Find("JournalPREFAB").GetComponent<Journal>();

        }

        clueCount = 0;
        foundCount = 0;
        tabCount = 0;
        waitingCount = 0;

        createTabs();

        tab1_button = GameObject.Find("Tab1").GetComponent<Button>();
        tab1_button.onClick.AddListener(switchTo1);
        tab2_button = GameObject.Find("Tab2").GetComponent<Button>();
        tab2_button.onClick.AddListener(switchTo2);
        tab3_button = GameObject.Find("Tab3").GetComponent<Button>();
        tab3_button.onClick.AddListener(switchTo3);


        isSolved = false;



        tab1.isDisplayed = true;


       


        switchTo1();

      


    }

    public List<Tab> getTabList()
    {

        return tabList;

    }


    //switch to tab1
    public void switchTo1()
    {
        GameObject.Find("Tabs_BG").GetComponent<Image>().sprite = bgImg1;
        tab1.isDisplayed = true;
        tab2.isDisplayed = false;
        tab3.isDisplayed = false;

        tabList[0].fillScreen();

    }

    public void switchTo2()
    {
        GameObject.Find("Tabs_BG").GetComponent<Image>().sprite = bgImg2;
        tab2.isDisplayed = true;
        tab1.isDisplayed = false;
        tab3.isDisplayed = false;

        tabList[1].fillScreen();


    }
    public void switchTo3()
    {

        GameObject.Find("Tabs_BG").GetComponent<Image>().sprite = bgImg3;
        tab3.isDisplayed = true;
        tab2.isDisplayed = false;
        tab1.isDisplayed = false;
        tabList[2].fillScreen();

    }

    //get the number of clues for the level
    public int getClueCount()
    {
        return clueCount;

    }


    //adds clue to the List of clues; instantiated at begining of level
    public void addClue(int clueNum)
    {

        bool tempBool = true;

        if (clueCount > 0) {
            for (int i = 0; i < clueCount; i++) {
                if (clueList[i].getClueNum() == clueNum) {
                    tempBool = false;

                }

            }
            

        }
        if (tempBool)
        {
            print("CLUENUM: " + clueNum);
            clueList.Add(Instantiate(clue));
            clueList[clueCount].setClueNum(clueNum);
            print(clueList[clueCount].getClueName());

            tempClue = clueList[clueCount];
            clueCount++;
            discoverClue(clueNum, tempClue);
        }
        
        
    }


    //level has been solved
    public void levelSolved()
    {

        isSolved = true;

    }

    //get isSolved
    public bool getIsSolved()
    {
        return isSolved;

    }

    //creates tabs
    public void createTabs()
    {

        tab1 = GameObject.Find("tabTest").GetComponent<Tab>();
        tab2 = GameObject.Find("tabTest2").GetComponent<Tab>();
        tab3 = GameObject.Find("tabTest3").GetComponent<Tab>();

        tabList.Add(tab1);
        tabList.Add(tab2);
        tabList.Add(tab3);

    }

    //item is found, increase foundCount
    public void increaseFoundCount(int clueNum)
    {
        print("foundcount: " + foundCount);


        if (foundCount > 5)
        {

            isSolved = true;
        }

        //tabList[tabCount].setClue1(tempClue);


        if (foundCount <= 5)
        {
            if (foundCount == 0)
            {
                tabList[tabCount].setClue1(tempClue);
                tabList[tabCount].clue1Valid = true;
                foundCount++;
                print("foundcount2: " + foundCount);
            }
            else if (foundCount % 2 != 0)
            {
                tabList[tabCount].setClue2(tempClue);
                tabList[tabCount].clue2Valid = true;

                foundCount++;
                
            }
            else
            {
                tabCount++;
                tabList[tabCount].setClue1(tempClue);
                tabList[tabCount].clue1Valid = true;

                foundCount++;

                if (tabCount == 1)
                {

                    GameObject.Find("Tab2_grey").SetActive(false);


                }
                else if (tabCount == 2)
                {

                    GameObject.Find("Tab3_grey").SetActive(false);


                }
            }
        }

    }

    //discovered clue
    public void discoverClue(int clueNum,Clue tempClue)
    {

        if (theJournal.getIsEnabled())
        {
            
                increaseFoundCount(clueNum);

            
        }
        else
        {

            waitingCount++;
            foundClues.Add(clueNum);
            print("waitingcount: " + waitingCount);

        }

    }


    // Update is called once per frame
    void Update()
    {
        if (theJournal.getIsEnabled() && waitingCount > 0)
        {

            for (int i = 0; i < waitingCount; i++)
            {
                increaseFoundCount(foundClues[i]);

            }
            waitingCount = 0;
            print("waitingcoung2: " + waitingCount);
            foundClues.Clear();
            tabList[0].fillScreen();
        }

    }
}