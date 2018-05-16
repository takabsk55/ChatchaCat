using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Catch : MonoBehaviour {
	public TextMesh catchText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void CatchText(){
		catchText.text="Catch!!!";
	}
}
