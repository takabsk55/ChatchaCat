using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skelton : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void Clicked(){
		GameObject.Find ("Master").GetComponent<Cells> ().Clear ();
		GetComponent<Renderer> ().material.color =new Color(1f,0.92f,0.016f,0.4f);
	}

}
