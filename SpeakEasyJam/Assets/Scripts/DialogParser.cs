using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogParser : MonoBehaviour {

	public TextAsset textFile;
	string[] dialogLines;
	int currentLine = 0;
	DialogCanvas dC;
	public PlayerController player;
	public bool questStarted = false;

	// Use this for initialization
	void Start () {
		dC = FindObjectOfType<DialogCanvas> ();
		if(textFile != null)
		{
			// Add each line of the text file to
			// the array using the new line
			// as the delimiter
			dialogLines = ( textFile.text.Split( '\n' ) );
		}
		for (int count = dialogLines.Length - 1; count >= 0; count--) {
			

		}
	}
	public void reloadTextFile(TextAsset text){
		textFile = text;
		if(textFile != null)
		{
			// Add each line of the text file to
			// the array using the new line
			// as the delimiter
			dialogLines = ( textFile.text.Split( '\n' ) );
		}
		for (int count = dialogLines.Length - 1; count >= 0; count--) {


		}
	}
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (player.transform.position, transform.position) <= 3) {
			
			if(Input.GetKeyDown(KeyCode.E)){
				dC.nameText.text= gameObject.name;
				dC.bodyText.text = nextLine ();
				dC.enableCanvas ();
				player.canMove = false;
			}
		} 
		if (Input.GetKeyDown (KeyCode.R)) {
			dC.disableCanvas ();
			player.canMove = true;
		}
	}

	string nextLine() {
		//this is for random npc barks
		if (dialogLines [0] == "Random" || dialogLines [0] == "random") {
			int count = (Random.Range (1, dialogLines.Length));
			while (dialogLines [count] == "" || dialogLines [count].Substring (0, 2) == "//" && count == currentLine) {
				count = (Random.Range (1, dialogLines.Length));
			}
			currentLine = count;
			return dialogLines [count];

		//this is for linear dialog it checks the last line of the text file, if it is number >0
		//it will repeat that many lines, but if it is 0 or less, it will end wiht "..." after finishing the dialog
		} 
		else if (dialogLines [0] == "incremental" || dialogLines [0] == "Incremental") {
			//if you are at the 2nd to last line in the text file it checks the last line for a number
			if (currentLine == dialogLines.Length - 2) {
				int n = 0;
				//checks if the last line is a number
				if (int.TryParse (dialogLines [dialogLines.Length - 1], out n)) {
					if (n < dialogLines.Length) {
						currentLine -= n - 1;
					} else {
						currentLine = 1;
					}
				}
			}
				//this is for linear dialog it checks the last line of the text file, if it is number >0
				//it will repeat that many lines, but if it is 0 or less, it will end wiht "..." after finishing the dialog
			else {
				currentLine += 1;
			}
			if (currentLine > dialogLines.Length - 2) {
				return "...";
			}
			else{
				return dialogLines [currentLine];
			}
		} 
		else if (dialogLines [0] == "incrementalQuest" || dialogLines [0] == "IncrementalQuest") {
			//if you are at the 2nd to last line in the text file it checks the last line for a number
			if (currentLine == dialogLines.Length - 2) {
				int n = 0;
				questStarted = true;
				//checks if the last line is a number
				if (int.TryParse (dialogLines [dialogLines.Length - 1], out n)) {
					if (n < dialogLines.Length) {
						currentLine -= n - 1;
					} else {
						currentLine = 1;
					}
				}
			
			}
			else {
				currentLine += 1;
			}
			if (currentLine > dialogLines.Length - 2) {
				return "...";
			}
			else{
				return dialogLines [currentLine];
			}
		}
		else {
			return "Error";
		}
	}
}
