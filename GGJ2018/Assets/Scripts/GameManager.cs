using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Monster
{
    public string name;
    public string majorWeakness;
    public string minorWeakness;
    public string majorStrength;
    public string minorStrength;
    public string FlavorOne;
    public string FlavorTwo;
}


public class GameManager : MonoBehaviour
{
    public Monster[] monsters;
	public InteractableObject[] hints;

	// Use this for initialization
	void Start ()
    {
		if(monsters.Length == 0)
        {
            Debug.LogError("There are no monsters to choose as escapees. Making a generic human escape instead.");
			monsters = new Monster[]
			{
				new Monster
				{
					name = "Human",
					majorWeakness = "Fire",
					minorWeakness = "Poison",
					majorStrength = "Water",
					minorStrength = "Air",
					FlavorOne = "Hammer",
					FlavorTwo = "Hat"
				},
			};
        }

		Monster culprit = monsters[Random.Range(0,monsters.Length)];
		Debug.Log("The escaped monster is " + culprit.name);

		//Getting all of the spawners
		GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");

		if(hints.Length == 0)
		{
			Debug.LogError("There aren't any hints to pull from! Creating a default one");
			hints = new InteractableObject[]
			{
				new InteractableObject()
				{
					tagName = "Water"
				},
			};
		}

		//GameObject majorWeakness;
		//GameObject minorWeakness;
		//GameObject majorStrength;
		//GameObject minorStrength;
		//GameObject FlavorOne;
		//GameObject FlavorTwo;
		List<InteractableObject> objsToSpawn = new List<InteractableObject>();

		Debug.Log("Looking for hints");
		for (int i = 0;i<hints.Length;i++)
		{
			if(hints[i].tagName == culprit.majorWeakness
				|| hints[i].tagName == culprit.minorWeakness
				|| hints[i].tagName == culprit.majorStrength
				|| hints[i].tagName == culprit.minorStrength
				|| hints[i].tagName == culprit.FlavorOne
				|| hints[i].tagName == culprit.FlavorTwo)
			{
				Debug.Log("Found a hint for the monster.");
				objsToSpawn.Add(hints[i]);
			}
		}

		for (int i = 0; i < objsToSpawn.Count; i++)
		{
			if(i < spawners.Length)
			{
				Debug.Log("Spawning " + objsToSpawn[i].tagName + " at a spawner");
				Instantiate(objsToSpawn[i], spawners[i].transform.position, Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
