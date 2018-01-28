using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Terminal : InteractableObject {
    private bool isReceiving;
    public bool isInteracting;
    public GameObject canvas;
    public Button optionOne;
    public Button optionTwo;
    public Button optionThree;
    public List<string> guesses;
    public int menuScreenCount = 0;
    GameManager managerScript;
    public List<string> answers;

    
    
	// Use this for initialization
	void Start () {

        tagName = "terminal";
        isReceiving = true;
        //gameObject.tag = tagName;
        isInteracting = false;
        

        optionOne.gameObject.SetActive(true);
        optionTwo.gameObject.SetActive(true);
        optionThree.gameObject.SetActive(true);
         GameObject manager = GameObject.Find("Game Manager");
        if(manager != null)
        {
            managerScript = manager.GetComponent<GameManager>();
        }
        SelectClues(managerScript.Culprit.majorWeakness);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isInteracting = !isInteracting;
            canvas.SetActive(isInteracting);
            
            
            
        }
        canvas.SetActive(isInteracting);
       

    }

    public void InteractWith()
    {
        if (isInteracting == true)
        {
            Status();
            isInteracting = false;
        }
        
    }
    public void Status()
    {
        if (isReceiving == true)
        {
            Debug.Log("Receiving");
            //call functions involving bringing the UI up
            isReceiving = false;
        }
        else
        {
            Debug.Log("Need Reply");

        }
    }
    //function to return the playstate of the terminal
    public bool PlayState()
    {

        return isInteracting;
    }

  
    public void ChangeButtons(string optionO, string optionT, string optionTr)
    {
        optionOne.GetComponentInChildren<Text>().text = optionO;
        optionTwo.GetComponentInChildren<Text>().text = optionT;
        optionThree.GetComponentInChildren<Text>().text = optionTr;
    }
    public void MenuToNext()
    {
        if (menuScreenCount == 0)
        {
            
            menuScreenCount++;
        }
        else if (menuScreenCount == 1)
        {
            
            menuScreenCount++;
            SelectClues(managerScript.Culprit.minorWeakness);
        }
        else if (menuScreenCount == 2)
        {
            SelectClues(managerScript.Culprit.majorStrength);
            menuScreenCount++;
        }
        else if (menuScreenCount == 3)
        {
            SelectClues(managerScript.Culprit.minorStrength);
            menuScreenCount++;
        }
        
        else if(menuScreenCount == 4)
        {
            optionTwo.GetComponentInChildren<Text>().text = "Submit";
            optionOne.gameObject.SetActive(false);
            optionThree.gameObject.SetActive(false);
            answers.RemoveAt(0);
            gameObject.GetComponent<Scoring>().Score(managerScript.Culprit, answers);
            menuScreenCount++;
            
        }
        else if(menuScreenCount == 5)
        {
            isInteracting = false;
            //menuScreenCount = 0;
        }
    }
    public void SelectClues(string correctAnswer)
    {
        List<InteractableObject> tempHints = managerScript.Hints;

        List<string> buttonItems = new List<string>();
        int i = 0;
        while( i<2 )
        {
            int location = Random.Range(0, tempHints.Count);
            string selection = tempHints[location].tagName;
            if(selection != correctAnswer)
            {
                tempHints.RemoveAt(location);
                buttonItems.Add(selection);
                i++; 
            }
            else
            {
                tempHints.RemoveAt(location);
               // buttonItems.Add(correctAnswer);
            }
            
        }
        buttonItems.Add(correctAnswer);

        List<string> finalList = new List<string>();

        for(int x = 0; x<3; x++)
        {
            int location = Random.Range(0, buttonItems.Count);
            string finalSelection = buttonItems[location];
            buttonItems.RemoveAt(location);
            finalList.Add(finalSelection);
        }
        ChangeButtons(finalList[0], finalList[1], finalList[2]);
    }
    public void ClueSelected(string selected)
    {
        answers.Add(selected);
    }

   
    
   

   
}
