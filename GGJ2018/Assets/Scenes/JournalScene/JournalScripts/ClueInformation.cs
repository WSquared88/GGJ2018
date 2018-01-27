using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClueInformation : MonoBehaviour {

    //string[] clueNames;
    //string[] clueDescs;
    //Sprite[] clueSprites;

    int rows = 25;//flavor text
    int columns = 1;//items
    string[,] traits = new string[25, 1];



	// Use this for initialization
	void Start () {
        //items
        traits[0, 0] = "Garlic";
        traits[1, 0] = "sunlight";
        traits[2, 0] = "blood";
        traits[3, 0] = "bullet casings";
        traits[4, 0] = "broken mirror";
        traits[5, 0] = "fur";
        traits[6, 0] = "bent steel";
        traits[7, 0] = "wolfsbane";
        traits[8, 0] = "silver";
        traits[9, 0] = "rebreather";
        traits[10, 0] = "fire";
        traits[11, 0] = "water";
        traits[12, 0] = "teeth";
        traits[13, 0] = "can of tuna";
        traits[14, 0] = "massive tracks";
        traits[15, 0] = "ice/snow";
        traits[16, 0] = "bloody meat";
        traits[17, 0] = "multiple tracks";
        traits[18, 0] = "damaged weapon";
        traits[19, 0] = "bars";
        traits[20, 0] = "harpoon ";
        traits[21, 0] = "punctured bodies";
        traits[22, 0] = "rocks";
        traits[23, 0] = "scorched floor";
        traits[24, 0] = "dust";
        //flavor text
        traits[0, 1] = "Perfect for spaghetti.";
        traits[1, 1] = "Wow that's brighter than my future.";
        traits[2, 1] = "That's not jelly.";
        traits[3, 1] = "That's not a good sign.";
        traits[4, 1] = "Well that's unlucky.";
        traits[5, 1] = "This must have been one big dog.";
        traits[6, 1] = "You have to be pretty strong to bend these things.";
        traits[7, 1] = "What a pretty flower.";
        traits[8, 1] = "oooo shiny";
        traits[9, 1] = "Who would even need this in space?";
        traits[10, 1] = "I'd put it out, but I forgot the fire extinguisher on Earth.";
        traits[11, 1] = "Salt water isn't great for consumption.";
        traits[12, 1] = "Too bad this job doesn't cover dental.";
        traits[13, 1] = "Oh cool, lunch.";
        traits[14, 1] = "Takes a blurry photo";
        traits[15, 1] = "Wish I had brought my jacket.";
        traits[16, 1] = "Human or animal? The world may never know.";
        traits[17, 1] = "One monster with many legs or many monsters with one leg?";
        traits[18, 1] = "Many the security in this place must be pretty bad.";
        traits[19, 1] = "Hmmmm the monster is gone, but the bars are still intact.";
        traits[20, 1] = "Stabby, stab, stab";
        traits[21, 1] = "I don't get paid enough to deal with this.";
        traits[22, 1] = "Not ideal for skipping.";
        traits[23, 1] = "Rements from a fire.";
        traits[24, 1] = "We really need to clean in here more often.";
    }

    //returns the name of the object based on the number that corresponds to it
    public string getName(int clueNumber) {
        return traits[clueNumber,0];

    }

    //returns the description of the object based on the number that corresponds to it
    public string getDesc(int clueNumber) {

        return traits[clueNumber,1];
    }

    //returns sprite to be used for Image
  //  public Sprite getImage(int clueNumber) {

       // return traits[clueNumber,];

//    }



	// Update is called once per frame
	void Update () {
		
	}
}
