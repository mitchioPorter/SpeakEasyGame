using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTemplate : MonoBehaviour {
	public string questType;
	public GameObject goal;
	public retrieval[] questItemList;
	bool goalComplete = false;

	// Use this for initialization
	void Start () {
		if (questType == "fetch") {
			//going to location adn grabbing n number of item or items
			foreach (retrieval item in questItemList) {
				if (item.numberOfItems != item.collectedNumberOfItems) {
					goalComplete = false;
				}
			}
			if (questType == "pickup") {
				//going to location, getting item from person
			}
			if (questType == "delivery") {
				//taking item to location and handing off to a person
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}


public class Quest{
	public string questType;
	public string name;
	public string description;
	QuestReciever goal;

	//retrieval
	Quest(retrieval[] retItems, string questName, string questDescription){
		questType = "retrieval";
		name = questName;
		description = questDescription;
	}
	//pickup
	Quest( QuestGiver qG, QuestReciever qR, string questName, string questDescription){
		questType = "pickup";
		name = questName;
		description = questDescription;
	}
	//delivery
	Quest( QuestReciever qR, string questName, string questDescription){
		questType = "delivery";
		name = questName;
		description = questDescription;
		goal = qR;
	}
}
