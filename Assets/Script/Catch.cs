using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Catch : MonoBehaviour {
	public TextMesh catchText;
	public GameObject obj;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		obj = GameObject.Find ("New Text");
		obj.transform.position =new Vector3 (obj.transform.position.x, obj.transform.position.y, (GameObject.Find ("MainCamera").transform.position.z+GameObject.Find ("Master").transform.position.z)/2);
	}
	public void CatchText(){
		catchText.text="Catch!!!";
	}
}
