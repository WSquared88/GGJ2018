using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Clue : MonoBehaviour {

    int clueNum;

    string clueName;
    Image clueImage;
    string clueDescription;

    bool isDiscovered;

    public Sprite sprite1;

    public ClueInformation clueInfo;

	// Use this for initialization
	void Start () {
        isDiscovered = false;
        
	}

    //sets clueNum
    public void setClueNum(int sentClueNum) {
        clueNum = sentClueNum;
        setClueName();
       // setClueImage();
        setClueDesc();

    }

    public int getClueNum() {

        return clueNum;
    }


    //sets clue name
    public void setClueName() {
        clueName = clueInfo.getName(clueNum);
    
    }
    
    //returns clueName
    public string getClueName() {
        return clueName;

    }

    //sets clue Image, goes through potential objects and then selects the corresponding sprite
    //public void setClueImage() {
        //clueImage.sprite = clueInfo.getImage(clueNum);

   // }


    //set journal Image
    public Image setJournalImage() {
        return clueImage;

    }


    //sets Clue description
    public void setClueDesc() {
        clueInfo.getDesc(clueNum);

    }


    //object is discovered
    public void setIsDiscovered() {

        isDiscovered = true;

    }

	// Update is called once per frame
	void Update () {
		
	}
}
