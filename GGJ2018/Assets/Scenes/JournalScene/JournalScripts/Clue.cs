﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Clue : MonoBehaviour
{

    int clueNum;

    string clueName;
    Sprite clueImage;
    string clueDescription;

    bool isDiscovered;

    public Sprite sprite1;

    ClueInformation clueInfo;

    // Use this for initialization
    void Start()
    {
        clueInfo = GameObject.Find("JournalPREFAB").GetComponent<ClueInformation>();
        isDiscovered = false;
        // setClueNum(clueNum);


    }

    //sets clueNum
    public void setClueNum(int sentClueNum)
    {
        clueNum = sentClueNum;
        setClueName();
        setClueImage();
        setClueDesc();

    }

    public int getClueNum()
    {

        return clueNum;
    }


    //sets clue name
    public void setClueName()
    {
        clueName = GameObject.Find("JournalPREFAB").GetComponent<ClueInformation>().getName(clueNum-1);
        print(clueName);

    }

    //returns clueName
    public string getClueName()
    {
        return clueName;

    }

    //sets clue Image, goes through potential objects and then selects the corresponding sprite
    public void setClueImage() {
        clueImage = GameObject.Find("JournalPREFAB").GetComponent<ClueInformation>().getImage(clueNum-1);

     }


    //set journal Image
    public Sprite getImage()
    {
        return clueImage;

    }


    //sets Clue description
    public void setClueDesc()
    {
        clueDescription = GameObject.Find("JournalPREFAB").GetComponent<ClueInformation>().getDesc(clueNum-1);
        // print(clueDescription);

    }

    //gets clue desc
    public string getClueDesc()
    {

        return clueDescription;

    }


    //object is discovered
    public void setIsDiscovered()
    {

        isDiscovered = true;

    }

    // Update is called once per frame
    void Update()
    {

    }
}