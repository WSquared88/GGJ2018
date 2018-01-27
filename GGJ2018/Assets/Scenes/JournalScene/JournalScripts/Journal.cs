using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Journal : MonoBehaviour {

    

    int levelCount;

    public Level_Journal currentLevel;

	// Use this for initialization
	void Start () {
       
		
	}



    //create a level
    public void createLevel() {
        currentLevel = Instantiate(currentLevel);
        

    }

    //delete a level
    public void deleteLevel() {

        Destroy(currentLevel);

    }

	// Update is called once per frame
	void Update () {

        

        		
	}
}
