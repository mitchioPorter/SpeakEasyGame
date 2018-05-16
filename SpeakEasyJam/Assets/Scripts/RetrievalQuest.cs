using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetrievalQuest : MonoBehaviour {
	retrieval[] objectives;
	public QuestGiver start;
	bool started = false;
	public float timer;
	public bool isTimed;
	public PlayerController player;
	bool allItemsCollected;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!started) {
			if (Vector3.Distance (start.transform.position, player.transform.position) < 3) {
				if (start.dialogParse.questStarted == true) {
					started = true;
				}
			}
		} else {
			if (!allItemsCollected) {
				
			}else{
				if (Vector3.Distance (start.transform.position, player.transform.position) < 3) {
					if (start.dialogParse.questStarted == true) {
						start.updateDialog ();
					}
				}
			}
		}
	}
}

public class retrieval{
	public int collectedNumberOfItems;
	public int numberOfItems;
	public item objectType;
	retrieval(item obj, int number){
		numberOfItems = number;	
	}
	retrieval(GameObject obj){
		numberOfItems = 1;
	}
	bool checkInventory(){
		return false;
	}
}
