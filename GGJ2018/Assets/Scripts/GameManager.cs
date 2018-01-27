using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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

    public Monster[] monsters;
	public GameObject[] hints;

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
			hints = new GameObject[]
			{
				new GameObject("Water"),
			};
		}

		//GameObject majorWeakness;
		//GameObject minorWeakness;
		//GameObject majorStrength;
		//GameObject minorStrength;
		//GameObject FlavorOne;
		//GameObject FlavorTwo;
		List<GameObject> objsToSpawn = new List<GameObject>();

		Debug.Log("Looking for hints");
		for (int i = 0;i<hints.Length;i++)
		{
			if(hints[i].name == culprit.majorWeakness
				|| hints[i].name == culprit.minorWeakness
				|| hints[i].name == culprit.majorStrength
				|| hints[i].name == culprit.minorStrength
				|| hints[i].name == culprit.FlavorOne
				|| hints[i].name == culprit.FlavorTwo)
			{
				Debug.Log("Found a hint for the monster.");
				objsToSpawn.Add(hints[i]);
			}
		}

		for (int i = 0; i < objsToSpawn.Count; i++)
		{
			if(i < spawners.Length)
			{
				Debug.Log("Spawning " + objsToSpawn[i].name + " at a spawner");
				Instantiate(objsToSpawn[i], spawners[i].transform.position, Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
