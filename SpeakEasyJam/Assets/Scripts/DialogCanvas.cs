using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogCanvas : MonoBehaviour {
	public RawImage person;
	public Text nameText;
	public Text bodyText;
	public Canvas canvas;
	// Use this for initialization
	void Start () {
		canvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void enableCanvas(){
		canvas.enabled = true;
	}
	public void disableCanvas(){
		canvas.enabled = false;
	}
}
