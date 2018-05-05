using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caractor : MonoBehaviour {
	public GameObject myChara;
	private Cells cell;
	private GameObject master;
	private GameObject myCells;
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
		master = GameObject.Find ("Master");
		cell = master.GetComponent<Cells>();	
		Debug.Log (myChara.transform.position.x);
		Debug.Log (cell.CellArray[1,1,1]);
	}

	void CalcCells(){
		float x = myChara.transform.position.x;
		float y = myChara.transform.position.y;
		float z = myChara.transform.position.z;
		if (y == -0.5) {
			y = 0;
		} else if (y == 0.5) {
			y = 1;	
		}
	}
}

