using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalButtonSelections : MonoBehaviour {
  
    Terminal terminalScript;
	// Use this for initialization
	void Start () {
        GameObject terminal = GameObject.Find("Terminal");
        terminalScript = terminal.GetComponent<Terminal>();
        if(!terminalScript)
        {
            Debug.LogError("The terminal script couldn't be found");
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    public void AnswerChoosen()
    {
        string selectedAnswer = gameObject.GetComponentInChildren<Text>().text;
        if (selectedAnswer != "Submit")
        {
            terminalScript.ClueSelected(selectedAnswer);
        }
        
    }
}
