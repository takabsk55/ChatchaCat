using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caractor : MonoBehaviour {
	public GameObject myChara;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (this.transform.position);
		Turn();
	}
	public Vector3 xy(){
		//Debug.Log (this.transform.position);
		return this.transform.position;
	}
	void Turn(){

		Debug.Log (myChara.transform.position.x);

	}
}

