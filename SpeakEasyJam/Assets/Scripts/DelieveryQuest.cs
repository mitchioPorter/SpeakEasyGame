using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelieveryQuest : MonoBehaviour {
	
	public QuestGiver start;
	public QuestReciever end;
	bool started = false;
	public float timer;
	public bool isTimed;
	public PlayerController player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!started) {
			if (Vector3.Distance (start.transform.position, player.transform.position) < 3) {
				if (start.dialogParse.questStarted == true) {
					started = true;
					end.updateDialog ();
					end.dialogParse.questStarted = true;
					started = true;
				}
			}
		} 
		else {
			if (Vector3.Distance (end.transform.position, player.transform.position) < 3) {
				if (end.dialogParse.questStarted == true) {
					start.updateDialog ();
				}
			}
		}
	}
}
