using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour {
	public GameObject myCell;
	private GameObject[,,] cell;
	private GameObject master;
	public GameObject myChara;
	// Use this for initialization
	void Start () {
		
		CalcCells();
	}
	
	// Update is called once per frame
	void Update () {
		master = GameObject.Find ("Master");
		cell = master.GetComponent<Cells>().CellArray;	
	}
	public void Turn(){
		strategy ();

	}
	public void strategy(){
		Vector3 rand;
		int a;
		List<Vector3> moveA=new List<Vector3>();
		List<Vector3> moveB=new List<Vector3>();
		List<Vector3> moveC=new List<Vector3>();

		moveA.Add (new Vector3 (-1, 0, 0));
		moveA.Add (new Vector3 (1, 0, 0));
		moveA.Add (new Vector3 (0, -1, 0));
		moveA.Add (new Vector3 (0, 1, 0));
		moveA.Add (new Vector3 (0, 0, -1));
		moveA.Add (new Vector3 (0, 0, 1));
		moveA.Shuffle ();
		master = GameObject.Find ("Master");
		cell = master.GetComponent<Cells>().CellArray;	
		while(true){
			rand = myChara.transform.position;

			for (int i = 0; i < moveA.Count; i++) {
				if (isMove (rand, moveA [i])) {
					moveB.Add (moveA [i]);
				}
			}


			myChara.transform.position = rand+moveB[1];
			break;
		}

		CalcCells();
	}

	public bool isMove(Vector3 randorigin,Vector3 temp){
		Vector3 rand = randorigin + temp;
		if (0<=rand.x&&rand.x<=3&&0<=rand.y&&rand.y<=1&&0<=rand.z&&rand.z<=3) {
			if (cell [(int)rand.x,(int)rand.y,(int)rand.z].layer != 0) {
				Debug.Log (cell [(int)rand.x,(int)rand.y,(int)rand.z].layer);
				return true;
			}
		}
		return false;
	}

	public void CalcCells(){
		int x = (int)myChara.transform.position.x;
		int z = (int)myChara.transform.position.z;
		int y=0;
		if (myChara.transform.position.y== -0.5) {
			y = 0;
		} else if (myChara.transform.position.y == 0.5) {
			y = 1;	
		}
		myCell=cell[x,y,z];
	}
}
