using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestReciever : MonoBehaviour {
	public TextAsset defaultText;
	public TextAsset questFinishedText;
	public DialogParser dialogParse;
	// Use this for initialization
	void Start () {
		dialogParse.reloadTextFile (defaultText);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateDialog(){
		dialogParse.reloadTextFile (questFinishedText);
	}
}
