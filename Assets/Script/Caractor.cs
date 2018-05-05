using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caractor : MonoBehaviour {
	public GameObject myCell;
	private Cells cell;
	private GameObject master;
	public GameObject myChara;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (this.transform.position);
		Turn ();
	}
	public Vector3 xy(){
		//Debug.Log (this.transform.position);
		return this.transform.position;
	}
	void Turn(){
		master = GameObject.Find ("Master");
		cell = master.GetComponent<Cells>();	
		CalcCells();
	}

	void CalcCells(){
		int x = (int)myChara.transform.position.x;
		int z = (int)myChara.transform.position.z;
		int y=0;
		if (myChara.transform.position.y== -0.5) {
			y = 0;
		} else if (myChara.transform.position.y == 0.5) {
			y = 1;	
		}

		myCell=cell.CellArray[x,y,z];
		myCell.GetComponent<Skelton> ().myChara =myChara;

	}


}

