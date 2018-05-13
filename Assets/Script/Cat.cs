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
		Vector3 catPosition;
		int a;
		List<Vector3> moveA=new List<Vector3>();//移動方向
		moveA.Add (new Vector3 (-1, 0, 0));
		moveA.Add (new Vector3 (1, 0, 0));
		moveA.Add (new Vector3 (0, -1, 0));
		moveA.Add (new Vector3 (0, 1, 0));
		moveA.Add (new Vector3 (0, 0, -1));
		moveA.Add (new Vector3 (0, 0, 1));
		moveA.Shuffle ();
		List<Vector3> moveB=new List<Vector3>();//動ける範囲
		List<Vector3> moveC=new List<Vector3>();//次に捕まらない

		master = GameObject.Find ("Master");
		cell = master.GetComponent<Cells>().CellArray;	
			moveB.Clear();
			moveC.Clear ();

			catPosition = myChara.transform.position;
			if (catPosition.y == 0.5) {
				catPosition=new Vector3(catPosition.x,1,catPosition.z);
			}
			if (catPosition.y == -0.5) {
				catPosition =new Vector3(catPosition.x,0f,catPosition.z);
			}

			for (int i = 0; i < moveA.Count; i++) {
				if (isMove (catPosition, moveA [i])) {
					moveB.Add (moveA [i]);
				}
			}

			//moveB
			Debug.Log ("kokokara");
			for (int j = 0; j < moveB.Count; j++) {
				if (isCatch (catPosition, moveB [j])) {
					moveC.Add (moveB [j]);
				Vector3 rand= new Vector3();
				rand = catPosition + moveB [j];
				Debug.Log (cell [(int)rand.x+1, (int)rand.y, (int)rand.z].layer);
				Debug.Log (cell [(int)rand.x-1, (int)rand.y, (int)rand.z].layer);
				Debug.Log (cell [(int)rand.x, (int)rand.y+1, (int)rand.z].layer);
				Debug.Log (cell [(int)rand.x, (int)rand.y-1, (int)rand.z].layer);
				Debug.Log (cell [(int)rand.x, (int)rand.y, (int)rand.z+1].layer);
				Debug.Log (cell [(int)rand.x, (int)rand.y, (int)rand.z-1].layer);

				}
			}
			if (moveC.Count == 0) {
				moveC.Add (moveB [0]);
				Debug.Log ("ssss");
			}
		
			Vector3 temp05 = new Vector3 (0f,-0.5f,0f);
			myChara.transform.position = catPosition+moveC[0]+temp05;

		CalcCells();
	}

	public bool isMove(Vector3 randorigin,Vector3 temp){
		Vector3 rand = randorigin + temp;
		if (0<=rand.x&&rand.x<=3&&0<=rand.y&&rand.y<=1&&0<=rand.z&&rand.z<=3) {
			if (cell [(int)rand.x,(int)rand.y,(int)rand.z].layer != 0) {
				return true;
			}
		}
		return false;
	}

	public bool isCatch(Vector3 randorigin,Vector3 temp){
		Vector3 rand = randorigin + temp;

		if ((int)rand.x + 1 <= 3) {
			if (cell [(int)rand.x + 1, (int)rand.y, (int)rand.z].layer == 0) {

				return false;
			}
		}
		else if ((int)rand.x - 1 >=0) {
			if (cell [(int)rand.x - 1, (int)rand.y, (int)rand.z].layer == 0) {
				return false;
			}
		}
		else if ((int)rand.y + 1 <= 1) {
			if (cell [(int)rand.x, (int)rand.y+1, (int)rand.z].layer == 0) {
				return false;
			}
		}
		else if ((int)rand.y - 1 >= 0) {
			if (cell [(int)rand.x , (int)rand.y-1, (int)rand.z].layer == 0) {
				return false;
			}
		}

		else if ((int)rand.z + 1 <= 3) {
			if (cell [(int)rand.x , (int)rand.y, (int)rand.z+1].layer == 0) {
				return false;
			}
		}
		else if ((int)rand.z - 1 >= 0) {
			if (cell [(int)rand.x , (int)rand.y, (int)rand.z-1].layer == 0) {
				return false;
			}
		}

		return true;
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
