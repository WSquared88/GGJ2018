using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//first data spot in list is always clue, second is always flavor text
public class InteractableObject : MonoBehaviour {
    public int seeDistance;
    public string clueText = "";
    public string flavorText = "";
    public string tagName = "";
	// Use this for initialization
	void Start () {

        gameObject.tag = tagName;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
    public List<string> giveStats()
    {
        List<string> info = new List<string>();
        info.Add(clueText);
        info.Add(flavorText);
        return info;

    }

        public virtual void assignValues(string clue, string flavor)
    {
        clueText = clue;
        flavorText = flavor;
    }
}
