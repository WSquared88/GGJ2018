﻿using System;
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
    List<Monster> monsters;
	List<InteractableObject> hints;
	[Tooltip("Filepath to the csv used for monster generation. Starts in the Assets folder. Ex: Assets/monsters.csv")]
	public string monsterListPath;
	[Tooltip("Filepath to the csv used for hint generation. Starts in the Assets folder. Ex: Assets/hints.csv")]
	public string hintListPath;
	Monster culprit;

    private void Awake()
    {
        GenerateMonsters();
        GenerateHints();

        if (monsters.Count == 0)
        {
            Debug.LogError("There are no monsters to choose as escapees. Making a generic human escape instead.");
            monsters.Add(
                new Monster()
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

        culprit = monsters[UnityEngine.Random.Range(0, monsters.Count)];
        Debug.Log("The escaped monster is " + culprit.name);

        if (hints.Count == 0)
        {
            Debug.LogError("There aren't any hints to pull from! Creating a default one");
            hints.Add(new InteractableObject()
            {
                tagName = "Water",
            });
        }
    }

    // Use this for initialization
    void Start ()
    {
		//GameObject majorWeakness;
		//GameObject minorWeakness;
		//GameObject majorStrength;
		//GameObject minorStrength;
		//GameObject FlavorOne;
		//GameObject FlavorTwo;
		List<InteractableObject> objsToSpawn = new List<InteractableObject>();
        //Getting all of the spawners
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");

        Debug.Log("Looking for hints");
		for (int i = 0;i<hints.Count;i++)
		{
			if(hints[i].tagName == culprit.majorWeakness
				|| hints[i].tagName == culprit.minorWeakness
				|| hints[i].tagName == culprit.majorStrength
				|| hints[i].tagName == culprit.minorStrength
				|| hints[i].tagName == culprit.FlavorOne
				|| hints[i].tagName == culprit.FlavorTwo)
			{
				Debug.Log("Found a " + hints[i].tagName + " for the monster.");
				objsToSpawn.Add(hints[i]);
			}
		}

		List<GameObject> unusedSpawns = new List<GameObject>(spawners);

		for (int i = 0; i < objsToSpawn.Count && unusedSpawns.Count > 0; i++)
		{
			int currentSpawner = UnityEngine.Random.Range(0, unusedSpawns.Count);
			GameObject hintObject = Resources.Load(objsToSpawn[i].tagName) as GameObject;

			if (!hintObject)
			{
				Debug.LogError("Unable to find " + objsToSpawn[i].tagName + " in the resourcers folder to load. Not spawning.");
			}
			else
			{
				Debug.Log("Spawning " + objsToSpawn[i].tagName + " at spawner number " + currentSpawner + " of " + unusedSpawns.Count + " at position " + unusedSpawns[currentSpawner].transform.position);
				GameObject spawnedHint = Instantiate(hintObject, unusedSpawns[currentSpawner].transform.position, Quaternion.identity);
				unusedSpawns.RemoveAt(currentSpawner);
				InteractableObject hint = spawnedHint.GetComponent<InteractableObject>();

				if (!hint)
				{
					Debug.LogError("Unable to get the InteractableObject component from the spawned hint object");
				}
				else
				{
					hint.clueText = objsToSpawn[i].clueText;
					hint.tagName = objsToSpawn[i].tagName;
					hint.flavorText = objsToSpawn[i].flavorText;
					hint.addToJournalDistance = objsToSpawn[i].addToJournalDistance;
					hint.numberInList = objsToSpawn[i].numberInList;
					hint.SetIsShaderStrong(hint.tagName == culprit.majorStrength
											|| hint.tagName == culprit.minorStrength);
				}
			}
		}

		//for (int i = 0; i < objsToSpawn.Count; i++)
		//{
		//	if(i < spawners.Length)
		//	{
		//		Debug.Log("Spawning " + objsToSpawn[i].tagName + " at a spawner");
		//		Instantiate(objsToSpawn[i], spawners[i].transform.position, Quaternion.identity);
		//	}
		//}
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

	void GenerateMonsters()
	{
		StreamReader reader;
		monsters = new List<Monster>();

		try
		{
			reader = new StreamReader(monsterListPath);
		}
		catch (FileNotFoundException)
		{
			Debug.LogError("The monster file was not in the location specified! Aborting monster generation!");
			return;
		}
		catch (ArgumentException)
		{
			Debug.LogError("No monster file path was provided! Aborting monster generation!");
			return;
		}

		reader.ReadLine();

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

	void GenerateHints()
	{
		StreamReader reader;
		hints = new List<InteractableObject>();

		try
		{
			reader = new StreamReader(hintListPath);
		}
		catch (FileNotFoundException)
		{
			Debug.LogError("The hint file was not in the location specified! Aborting hint generation!");
			return;
		}
		catch(ArgumentException)
		{
			Debug.LogError("No hint file path was provided! Aborting hint generation!");
			return;
		}

		reader.ReadLine();

		while (!reader.EndOfStream)
		{
			string line = reader.ReadLine();
			string[] words = line.Split('\t');
			Debug.Log("Parsing out line: " + line);

			if (words.Length < 4)
			{
				Debug.LogError("The hint list isn't set up correctly.");
			}
			else
			{
				//InteractableObject hint;// = new InteractableObject
				////{
				////	tagName = words[0],
				////	flavorText = words[1],
				////	seeDistance = int.Parse(words[2]),
				////};

				//hint = GameObject.CreatePrimitive(PrimitiveType.Sphere).AddComponent<InteractableObject>();
				int addToJournalDistance;
				int numInList;
				bool journalResult = int.TryParse(words[2], out addToJournalDistance);
				bool numResult = int.TryParse(words[3], out numInList);

				hints.Add(new InteractableObject()
				{
					tagName = words[0],
					flavorText = words[1],
					addToJournalDistance = journalResult ? addToJournalDistance : 5,
                    numberInList = numResult ? numInList : -1,
				});

                Debug.Log("Making a new hint." +
                    "\nTag Name: " + words[0] +
                    "\nFlavor Text: " + words[1] +
                    "\n Sight Distance: " + (journalResult ? addToJournalDistance : 5) +
                    "\n Number in List: " + (numResult ? numInList : -1));
			}
		}
	}

	void SubmitAnswers(List<string> answers)
	{

	}

	public Monster Culprit
	{
		get
		{
			return culprit;
            
		}
       
	}
   public List<InteractableObject> Hints
    {
        get
        {
            return hints;
        }
    }
}
