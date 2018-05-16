using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Catch : MonoBehaviour {
	public GameObject obj;
	public Image catchImg;
	public Image gameOverImg;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	public void CatchImage(){
		catchImg.enabled = true;
	}
	public void GameOverImage(){
		gameOverImg.enabled = true;
	}
}
