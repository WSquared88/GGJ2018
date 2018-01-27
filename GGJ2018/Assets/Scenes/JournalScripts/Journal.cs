using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Journal : MonoBehaviour {

    

    int levelCount;

    Level_Journal currentLevel;

	// Use this for initialization
	void Start () {
        createLevel();
		
	}



    //create a level
    public void createLevel() {
        currentLevel = new Level_Journal();
        

    }

    //delete a level
    public void deleteLevel() {

        Destroy(currentLevel);

    }

	// Update is called once per frame
	void Update () {

        if (currentLevel.getIsSolved() == true) {
            deleteLevel();
            if (levelCount <= 9)
            {
                createLevel();
            }
           
        }
        		
	}
}
