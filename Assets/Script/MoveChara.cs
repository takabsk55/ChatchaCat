using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChara : MonoBehaviour {

	public GameObject obj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MoveCat(Vector3 vec){
		var moveHash = new Hashtable ();
		moveHash.Add ("position", vec);
		moveHash.Add ("delay", 0.5f);
		iTween.MoveTo (obj, moveHash);
	}
	public void MoveCharactor(Vector3 vec){
		var moveHash = new Hashtable ();
		moveHash.Add ("position", vec);
		iTween.MoveTo (obj, moveHash);
	}
}
