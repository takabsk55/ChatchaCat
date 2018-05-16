using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skelton : MonoBehaviour {
	// Use this for initialization
	public GameObject myChara;
	public GameObject myCharaTemp;
	public int x,y,z;
	public int range;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}
	public void Clicked(){
		if (this.gameObject.layer == 0) {
			GameObject.Find ("Master").GetComponent<Cells> ().ClearColor ();
			GetComponent<Renderer> ().material.color = new Color (1f, 0.92f, 0.016f, 0.4f);
			CalcRange ();
		} else if (this.gameObject.layer == 9) {
			GameObject.Find ("Master").GetComponent<Cells> ().InitCells ();
			var moveHash = new Hashtable ();
			Vector3 vec = new Vector3 (x, y - 0.5f, z);
			moveHash.Add ("position", vec);
			moveHash.Add("oncompletetarget",this.gameObject);
			moveHash.Add ("oncomplete", "end");


			GameObject.Find ("Master").GetComponent<Cells> ().ClearColor ();

			GameObject.Find (myCharaTemp.name).GetComponent<Caractor> ().CalcCells();


			iTween.MoveTo(myCharaTemp,moveHash);
			Debug.Log ("catch");
			GameObject.Find ("Canvas").GetComponent<Catch> ().CatchText ();


		}else if (this.gameObject.layer == 8) {
			if (GameObject.Find ("cat_Idle").GetComponent<Cat> ().myCell == GameObject.Find ("Master").GetComponent<Cells> ().CellArray [this.x, this.y, this.z]) {

			}
			GameObject.Find ("Master").GetComponent<Cells> ().InitCells ();
			var moveHash = new Hashtable ();
			Vector3 vec = new Vector3 (x, y - 0.5f, z);
			moveHash.Add ("position", vec);
			moveHash.Add("oncompletetarget",this.gameObject);
			moveHash.Add ("oncomplete", "end");


			GameObject.Find ("Master").GetComponent<Cells> ().ClearColor ();

			GameObject.Find (myCharaTemp.name).GetComponent<Caractor> ().CalcCells();


			iTween.MoveTo(myCharaTemp,moveHash);

			//ここでターンを減らす
			GameObject.Find ("cat_Idle").GetComponent<Cat> ().CatLife--;
			if (GameObject.Find ("cat_Idle").GetComponent<Cat> ().CatLife != 0) {
				GameObject.Find ("RedBar").GetComponent<Hpbar> ().Life();
				GameObject.Find ("cat_Idle").GetComponent<Cat> ().Turn ();
			}else if(GameObject.Find ("cat_Idle").GetComponent<Cat> ().CatLife==0){
				GameObject.Find ("RedBar").GetComponent<Hpbar> ().Life();

				GameObject.Find ("Canvas").GetComponent<Catch> ().GameOverText ();
			}

		} else {
			
		}
	}

	public void end(){
		
		GameObject.Find (myCharaTemp.name).GetComponent<Caractor> ().CalcCells();
		myChara = myCharaTemp;
		GameObject.Find (myChara.name).GetComponent<Caractor> ().myCell = GameObject.Find("Master").GetComponent<Cells>().CellArray[x,y,z];

		GameObject.Find (myChara.name).GetComponent<Caractor> ().CalcCells();
		GameObject.Find ("Master").GetComponent<Cells> ().InitCells ();

		Debug.Log ("wait");

	}

	private IEnumerator Wait(){
		yield return new WaitForSeconds (1.0f);

	}

	public void ManegeLayer(){
		if (myChara != null) {
			GameObject.Find ("Master").GetComponent<Cells> ().CellArray [x, y, z].layer = 0;
		} else {
			GameObject.Find ("Master").GetComponent<Cells> ().CellArray [x, y, z].layer = 2;

		}
	}

	public void ChangeColor(){
		GetComponent<Renderer> ().material.color =new Color(1f,0.92f,0.016f,0.4f);

	}

	void CalcRange(){
		int myCharaRange = myChara.GetComponent<Piece> ().range;
		int rangeTemp;
		Skelton skeltonTemp;
		GameObject[,,] CellArrayTemp=GameObject.Find ("Master").GetComponent<Cells> ().CellArray;
		CellArrayTemp [x, y, z].GetComponent<Skelton> ().range = myCharaRange;
		Stack<GameObject> stack = new Stack<GameObject> (){ };
		stack.Push (CellArrayTemp[x,y,z]);
		while(true){
			if (stack.Count==0) {
				break;
			}
			skeltonTemp=stack.Pop ().GetComponent<Skelton>();
			CellArrayTemp [skeltonTemp.x, skeltonTemp.y, skeltonTemp.z].GetComponent<Skelton> ().ChangeColor ();
			if (skeltonTemp.range == 0) {
				continue;
			}

			rangeTemp=CellArrayTemp [skeltonTemp.x, skeltonTemp.y, skeltonTemp.z].GetComponent<Skelton>().range-1;

			for (int xt = -1; xt <= 1; xt += 2) {
				try {
					if (CellArrayTemp [skeltonTemp.x + xt, skeltonTemp.y , skeltonTemp.z ].layer != 0) {
						CellArrayTemp [skeltonTemp.x+xt, skeltonTemp.y, skeltonTemp.z].layer = 8;
						CellArrayTemp [skeltonTemp.x+xt, skeltonTemp.y, skeltonTemp.z].GetComponent<Skelton>().myCharaTemp=this.myChara;
						CellArrayTemp [skeltonTemp.x+xt, skeltonTemp.y, skeltonTemp.z].GetComponent<Skelton>().range=rangeTemp;
						stack.Push (CellArrayTemp [skeltonTemp.x + xt, skeltonTemp.y , skeltonTemp.z ]);
					}	
				} catch {
				}
			}
			for (int yt = -1; yt <= 1; yt += 2) {
				try {
					if (CellArrayTemp [skeltonTemp.x , skeltonTemp.y + yt, skeltonTemp.z ].layer != 0) {
						CellArrayTemp [skeltonTemp.x, skeltonTemp.y+yt, skeltonTemp.z].layer = 8;
						CellArrayTemp [skeltonTemp.x, skeltonTemp.y+yt, skeltonTemp.z].GetComponent<Skelton>().myCharaTemp=this.myChara;
						CellArrayTemp [skeltonTemp.x, skeltonTemp.y+yt, skeltonTemp.z].GetComponent<Skelton>().range=rangeTemp;
						stack.Push (CellArrayTemp [skeltonTemp.x , skeltonTemp.y + yt, skeltonTemp.z ]);
					}	
				} catch {
				}
			}
			for (int zt = -1; zt <= 1; zt += 2) {
				try {
					if (CellArrayTemp [skeltonTemp.x , skeltonTemp.y , skeltonTemp.z + zt].layer != 0) {		
						CellArrayTemp [skeltonTemp.x, skeltonTemp.y, skeltonTemp.z+zt].layer = 8;
						CellArrayTemp [skeltonTemp.x, skeltonTemp.y, skeltonTemp.z+zt].GetComponent<Skelton>().myCharaTemp=this.myChara;
						CellArrayTemp [skeltonTemp.x, skeltonTemp.y, skeltonTemp.z+zt].GetComponent<Skelton>().range=rangeTemp;
						stack.Push (CellArrayTemp [skeltonTemp.x , skeltonTemp.y , skeltonTemp.z + zt]);
					}	
				} catch {
				}
			}

		}
		for(int x=0;x<4;x++){
			for(int y=0;y<2;y++){
				for(int z=0;z<4;z++){
					GameObject.Find ("Master").GetComponent<Cells> ().CellArray[x,y,z]=CellArrayTemp[x,y,z];
				}
			}
		}


	}

}
