using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cells : MonoBehaviour {
	public GameObject[,,] CellArray;


	// Use this for initialization
	void Start () {
		CellArray=new GameObject[4, 2, 4];
		CellArray [0, 0, 0] = GameObject.Find ("skelton111");
		CellArray [0, 0, 1] = GameObject.Find ("skelton112");
		CellArray [0, 0, 2] = GameObject.Find ("skelton113");
		CellArray [0, 0, 3] = GameObject.Find ("skelton114");
		CellArray [1, 0, 0] = GameObject.Find ("skelton121");
		CellArray [1, 0, 1] = GameObject.Find ("skelton122");
		CellArray [1, 0, 2] = GameObject.Find ("skelton123");
		CellArray [1, 0, 3] = GameObject.Find ("skelton124");
		CellArray [2, 0, 0] = GameObject.Find ("skelton131");
		CellArray [2, 0, 1] = GameObject.Find ("skelton132");
		CellArray [2, 0, 2] = GameObject.Find ("skelton133");
		CellArray [2, 0, 3] = GameObject.Find ("skelton134");
		CellArray [3, 0, 0] = GameObject.Find ("skelton141");
		CellArray [3, 0, 1] = GameObject.Find ("skelton142");
		CellArray [3, 0, 2] = GameObject.Find ("skelton143");
		CellArray [3, 0, 3] = GameObject.Find ("skelton144");
		CellArray [0, 1, 0] = GameObject.Find ("skelton211");
		CellArray [0, 1, 1] = GameObject.Find ("skelton212");
		CellArray [0, 1, 2] = GameObject.Find ("skelton213");
		CellArray [0, 1, 3] = GameObject.Find ("skelton214");
		CellArray [1, 1, 0] = GameObject.Find ("skelton221");
		CellArray [1, 1, 1] = GameObject.Find ("skelton222");
		CellArray [1, 1, 2] = GameObject.Find ("skelton223");
		CellArray [1, 1, 3] = GameObject.Find ("skelton224");
		CellArray [2, 1, 0] = GameObject.Find ("skelton231");
		CellArray [2, 1, 1] = GameObject.Find ("skelton232");
		CellArray [2, 1, 2] = GameObject.Find ("skelton233");
		CellArray [2, 1, 3] = GameObject.Find ("skelton234");
		CellArray [3, 1, 0] = GameObject.Find ("skelton241");
		CellArray [3, 1, 1] = GameObject.Find ("skelton242");
		CellArray [3, 1, 2] = GameObject.Find ("skelton243");
		CellArray [3, 1, 3] = GameObject.Find ("skelton244");
	}
	
	// Update is called once per frame
	void Update () {
	}
	public void ClearColor(){
		for (int i = 0; i <= 3; i++) {
			for (int j = 0; j <= 1; j++) {
				for (int k = 0; k <= 3; k++) {
					CellArray[i,j,k].GetComponent<Renderer>().material.color=new Color(1f,0.92f,0.016f,0f);
				}
			}
		}
	}

}
