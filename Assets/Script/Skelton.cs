﻿using System.Collections;
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
		} else if (this.gameObject.layer == 8) {
			if (GameObject.Find ("cat_Idle").GetComponent<Cat> ().myCell == GameObject.Find ("Master").GetComponent<Cells> ().CellArray [this.x, this.y, this.z]) {
				Debug.Log ("catch!!!");
			}
			GameObject.Find ("Master").GetComponent<Cells> ().InitCells ();
			GameObject.Find (myCharaTemp.name).transform.position = new Vector3 (x, y-0.5f, z);
			GameObject.Find (myCharaTemp.name).GetComponent<Caractor> ().CalcCells();
			myChara = myCharaTemp;
			GameObject.Find (myChara.name).GetComponent<Caractor> ().myCell = GameObject.Find("Master").GetComponent<Cells>().CellArray[x,y,z];
			GameObject.Find ("Master").GetComponent<Cells> ().ClearColor ();
			GameObject.Find (myChara.name).GetComponent<Caractor> ().CalcCells();
			GameObject.Find ("cat_Idle").GetComponent<Cat> ().Turn ();
		} else {
			
		}
	}

	public void ManegeLayer(){
		if (myChara != null) {
			GameObject.Find ("Master").GetComponent<Cells> ().CellArray [x, y, z].layer = 0;
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
