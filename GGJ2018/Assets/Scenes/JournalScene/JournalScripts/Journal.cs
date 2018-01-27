using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Journal : MonoBehaviour {


    bool newLevelStart;

    int levelCount;

    public Level_Journal currentLevel;

    GameObject journalView;
    bool isEnabled;

	// Use this for initialization
	void Start () {

        newLevelStart = false;
        journalView = GameObject.Find("JournalView");
        isEnabled = false;
        journalView.SetActive(isEnabled);

       


    }




    public bool getIsEnabled() {

        return isEnabled;
    }


    // Update is called once per frame
    void Update() {

       

        if (Input.GetKeyDown(KeyCode.Tab)) {
            journalView.SetActive(!isEnabled);
            isEnabled = !isEnabled;
    }


        

    }
}
