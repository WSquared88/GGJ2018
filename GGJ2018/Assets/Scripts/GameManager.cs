using System.Collections;
using System.Collections.Generic;
using System.IO;
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
	[Tooltip("Filepath to the csv used for monster generation. Starts in the Assets folder. Ex: Assets/monsters.csv")]
	public string monsterList;

	// Use this for initialization
	void Start ()
    {
		GenerateMonsters();

		if(monsters.Count == 0)
        {
            Debug.LogError("There are no monsters to choose as escapees. Making a generic human escape instead.");
			monsters.Add(
				new Monster
				{
					name = "Human",
					majorWeakness = "Fire",
					minorWeakness = "Poison",
					majorStrength = "Water",
					minorStrength = "Air",
					FlavorOne = "Hammer",
					FlavorTwo = "Hat"
				}
			);
        }

		Monster culprit = monsters[Random.Range(0,monsters.Count)];
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

	void GenerateMonsters()
	{
		StreamReader reader;

		try
		{
			reader = new StreamReader(monsterList);
		}
		catch (FileNotFoundException)
		{
			Debug.LogError("The monster file was not in the location specified! Aborting monster generation!");
			return;
		}

		reader.ReadLine();
		monsters = new List<Monster>();

		while (!reader.EndOfStream)
		{
			string line = reader.ReadLine();
			string[] words = line.Split(',');
			Debug.Log("Parsing out line: " + line);

			if (words.Length < 7)
			{
				Debug.LogError("The monster list isn't set up correctly.");
			}
			else
			{

				monsters.Add(new Monster
				{
					name = words[0],
					majorWeakness = words[1],
					minorWeakness = words[2],
					majorStrength = words[3],
					minorStrength = words[4],
					FlavorOne = words[5],
					FlavorTwo = words[6]
				});

				Debug.Log("Making a new monster." +
					"\nName: " + words[0] +
					"\nmajor weakness: " + words[1] +
					"\n minor weakness: " + words[2] +
					"\nmajor strength: " + words[3] +
					"\nminor strength: " + words[4] +
					"\nflavor one: " + words[5] +
					"\n flavor two: " + words[6]);
			}
		}
	}
}
