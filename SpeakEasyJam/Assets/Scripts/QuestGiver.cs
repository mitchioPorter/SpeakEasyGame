using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour {
	public TextAsset defaultText;
	public TextAsset preQuestText;
	public DialogParser dialogParse;

	// Use this for initialization
	void Start () {
		dialogParse.reloadTextFile (preQuestText);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void updateDialog(){
		dialogParse.reloadTextFile (defaultText);
	}
}
