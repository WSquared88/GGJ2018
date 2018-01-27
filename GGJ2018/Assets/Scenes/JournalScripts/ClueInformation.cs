using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClueInformation : MonoBehaviour {

    string[] clueNames;
    string[] clueDescs;
    Sprite[] clueSprites;

	// Use this for initialization
	void Start () {
		
	}

    //returns the name of the object based on the number that corresponds to it
    public string getName(int clueNumber) {
        return clueNames[clueNumber];

    }

    //returns the description of the object based on the number that corresponds to it
    public string getDesc(int clueNumber) {

        return clueDescs[clueNumber];
    }


    //returns sprite to be used for Image
    public Sprite getImage(int clueNumber) {

        return clueSprites[clueNumber];

    }



	// Update is called once per frame
	void Update () {
		
	}
}
