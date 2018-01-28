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
    
    
	// Use this for initialization
	void Start () {

        tagName = "terminal";
        isReceiving = true;
        //gameObject.tag = tagName;
        isInteracting = false;
        Menu();
        ChangeButtons("Hah", "Hahahaha", "HAHAHAHAHAHAHAHAHAHAH");
        optionOne.gameObject.SetActive(true);
        optionTwo.gameObject.SetActive(true);
        optionThree.gameObject.SetActive(true);
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
       // optionOne.onClick.AddListener((UnityEngine.Events.UnityAction)this.MenuToNext);
       // optionTwo.onClick.AddListener((UnityEngine.Events.UnityAction)this.MenuToNext);
       // optionThree.onClick.AddListener((UnityEngine.Events.UnityAction)this.MenuToNext);

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

    public void Menu()
    {
       
        
    }
    public void ChangeButtons(string optionO, string optionT, string optionTr)
    {
        optionOne.GetComponentInChildren<Text>().text = optionO;
        optionTwo.GetComponentInChildren<Text>().text = optionT;
        optionThree.GetComponentInChildren<Text>().text = optionTr;
    }
    public void MenuToNext()
    {
        if (menuScreenCount < 4)
        {
            ChangeButtons("Test " + menuScreenCount, "Test " + menuScreenCount, "Test " + menuScreenCount);
            menuScreenCount++;
        }
        else
        {
            optionTwo.GetComponentInChildren<Text>().text = "Submit";
            optionOne.gameObject.SetActive(false);
            optionThree.gameObject.SetActive(false);
        }
    }

   
    
   

   
}
