using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour {
    public string[] objectsFound;
    public int playerScore;
    // Use this for initialization
    void Start () {
		
	}
	public int Score(Monster monster, List<string> answers)
    {
        string[] objectsToBeFound = new string[4];
        objectsFound = new string[4];
        playerScore = 0;

        objectsToBeFound[0] = monster.majorWeakness;
        objectsToBeFound[1] = monster.minorWeakness;
        objectsToBeFound[2] = monster.majorStrength;
        objectsToBeFound[3] = monster.minorStrength;

        foreach(string clue in objectsToBeFound)
        {
            Debug.Log(clue);
        }
        Debug.Log(answers[0]);

        for(int i=0; i<objectsToBeFound.Length;i++)
        {
            if(objectsToBeFound[i]==answers[i])
            {
                playerScore++;
            }
        }
        return playerScore;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
