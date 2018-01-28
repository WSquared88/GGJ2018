using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClueInformation : MonoBehaviour
{

    //string[] clueNames;
    //string[] clueDescs;
    //Sprite[] clueSprites;

    int rows = 25; //flavor text
    int columns = 1; //items
    string[,] traits = new string[25, 2];

    Sprite[] clueImages = new Sprite[25];

    // Use this for initialization
    void Start()
    {
        //items
        traits[0, 0] = "Garlic";
        traits[1, 0] = "Sunlight";
        traits[2, 0] = "Blood";
        traits[3, 0] = "Bullet casings";
        traits[4, 0] = "Broken Mirror";
        traits[5, 0] = "Fur";
        traits[6, 0] = "Bent Steel";
        traits[7, 0] = "Wolfsbane";
        traits[8, 0] = "Silver";
        traits[9, 0] = "Rebreather";
        traits[10, 0] = "Fire";
        traits[11, 0] = "Water";
        traits[12, 0] = "Teeth";
        traits[13, 0] = "Can of Tuna";
        traits[14, 0] = "Massive Tracks";
        traits[15, 0] = "Ice/Snow";
        traits[16, 0] = "Bloody Meat";
        traits[17, 0] = "Multiple Tracks";
        traits[18, 0] = "Damaged Weapon";
        traits[19, 0] = "Bars";
        traits[20, 0] = "Harpoon ";
        traits[21, 0] = "Punctured Bodies";
        traits[22, 0] = "Rocks";
        traits[23, 0] = "Scorched Floor";
        traits[24, 0] = "Dust";
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

        //images

        clueImages[0]= Resources.Load<Sprite>("cat");
        clueImages[1] = Resources.Load<Sprite>("cat");
        clueImages[2] = Resources.Load<Sprite>("cat");
        clueImages[3] = Resources.Load<Sprite>("cat");
        clueImages[4] = Resources.Load<Sprite>("cat");
        clueImages[5] = Resources.Load<Sprite>("cat");
        clueImages[6] = Resources.Load<Sprite>("cat");
        clueImages[7] = Resources.Load<Sprite>("cat");
        clueImages[8] = Resources.Load<Sprite>("cat");
        clueImages[9] = Resources.Load<Sprite>("cat");
        clueImages[10] = Resources.Load<Sprite>("cat");
        clueImages[11] = Resources.Load<Sprite>("cat");
        clueImages[12] = Resources.Load<Sprite>("cat");
        clueImages[13] = Resources.Load<Sprite>("cat");
        clueImages[14] = Resources.Load<Sprite>("cat");
        clueImages[15] = Resources.Load<Sprite>("cat");
        clueImages[16] = Resources.Load<Sprite>("cat");
        clueImages[17] = Resources.Load<Sprite>("cat");
        clueImages[18] = Resources.Load<Sprite>("cat");
        clueImages[19] = Resources.Load<Sprite>("cat");
        clueImages[20] = Resources.Load<Sprite>("cat");
        clueImages[21] = Resources.Load<Sprite>("cat");
        clueImages[22] = Resources.Load<Sprite>("cat");
        clueImages[23] = Resources.Load<Sprite>("cat");
        clueImages[24] = Resources.Load<Sprite>("cat");

    }

    //returns the name of the object based on the number that corresponds to it
    public string getName(int clueNumber)
    {
        return traits[clueNumber, 0];

    }

    //returns the description of the object based on the number that corresponds to it
    public string getDesc(int clueNumber)
    {

        return traits[clueNumber, 1];
    }

    //returns sprite to be used for Image
      public Sprite getImage(int clueNumber) {

             return clueImages[clueNumber];
        
        }



    // Update is called once per frame
    void Update()
    {

    }
}