using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cells : MonoBehaviour {
	public GameObject[,,] CellArray;
	// Use this for initialization
	void Start () {
		CellArray=new GameObject[4, 4, 2];
		CellArray [0, 0, 0] = GameObject.Find ("skelton111");
		CellArray [1, 0, 0] = GameObject.Find ("skelton112");
		CellArray [2, 0, 0] = GameObject.Find ("skelton113");
		CellArray [3, 0, 0] = GameObject.Find ("skelton114");
		CellArray [0, 1, 0] = GameObject.Find ("skelton121");
		CellArray [1, 1, 0] = GameObject.Find ("skelton122");
		CellArray [2, 1, 0] = GameObject.Find ("skelton123");
		CellArray [3, 1, 0] = GameObject.Find ("skelton124");
		CellArray [0, 2, 0] = GameObject.Find ("skelton131");
		CellArray [1, 2, 0] = GameObject.Find ("skelton132");
		CellArray [2, 2, 0] = GameObject.Find ("skelton133");
		CellArray [3, 2, 0] = GameObject.Find ("skelton134");
		CellArray [0, 3, 0] = GameObject.Find ("skelton141");
		CellArray [1, 3, 0] = GameObject.Find ("skelton142");
		CellArray [2, 3, 0] = GameObject.Find ("skelton143");
		CellArray [3, 3, 0] = GameObject.Find ("skelton144");
		CellArray [0, 0, 1] = GameObject.Find ("skelton211");
		CellArray [1, 0, 1] = GameObject.Find ("skelton212");
		CellArray [2, 0, 1] = GameObject.Find ("skelton213");
		CellArray [3, 0, 1] = GameObject.Find ("skelton214");
		CellArray [0, 1, 1] = GameObject.Find ("skelton221");
		CellArray [1, 1, 1] = GameObject.Find ("skelton222");
		CellArray [2, 1, 1] = GameObject.Find ("skelton223");
		CellArray [3, 1, 1] = GameObject.Find ("skelton224");
		CellArray [0, 2, 1] = GameObject.Find ("skelton231");
		CellArray [1, 2, 1] = GameObject.Find ("skelton232");
		CellArray [2, 2, 1] = GameObject.Find ("skelton233");
		CellArray [3, 2, 1] = GameObject.Find ("skelton234");
		CellArray [0, 3, 1] = GameObject.Find ("skelton241");
		CellArray [1, 3, 1] = GameObject.Find ("skelton242");
		CellArray [2, 3, 1] = GameObject.Find ("skelton243");
		CellArray [3, 3, 1] = GameObject.Find ("skelton244");

		Debug.Log (CellArray[0,0,0].transform.position.x
		);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
