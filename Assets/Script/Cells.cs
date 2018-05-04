using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cells : MonoBehaviour {
	public GameObject[,,] CellArray;
	// Use this for initialization
	void Start () {
		CellArray=new GameObject[4, 4, 2];
		CellArray [0, 0, 0] = GameObject.Find ("skeleton111");
		CellArray [1, 0, 0] = GameObject.Find ("skeleton112");
		CellArray [2, 0, 0] = GameObject.Find ("skeleton113");
		CellArray [3, 0, 0] = GameObject.Find ("skeleton114");
		CellArray [0, 1, 0] = GameObject.Find ("skeleton121");
		CellArray [1, 1, 0] = GameObject.Find ("skeleton122");
		CellArray [2, 1, 0] = GameObject.Find ("skeleton123");
		CellArray [3, 1, 0] = GameObject.Find ("skeleton124");
		CellArray [0, 2, 0] = GameObject.Find ("skeleton131");
		CellArray [1, 2, 0] = GameObject.Find ("skeleton132");
		CellArray [2, 2, 0] = GameObject.Find ("skeleton133");
		CellArray [3, 2, 0] = GameObject.Find ("skeleton134");
		CellArray [0, 3, 0] = GameObject.Find ("skeleton141");
		CellArray [1, 3, 0] = GameObject.Find ("skeleton142");
		CellArray [2, 3, 0] = GameObject.Find ("skeleton143");
		CellArray [3, 3, 0] = GameObject.Find ("skeleton144");
		CellArray [0, 0, 1] = GameObject.Find ("skeleton211");
		CellArray [1, 0, 1] = GameObject.Find ("skeleton212");
		CellArray [2, 0, 1] = GameObject.Find ("skeleton213");
		CellArray [3, 0, 1] = GameObject.Find ("skeleton214");
		CellArray [0, 1, 1] = GameObject.Find ("skeleton221");
		CellArray [1, 1, 1] = GameObject.Find ("skeleton222");
		CellArray [2, 1, 1] = GameObject.Find ("skeleton223");
		CellArray [3, 1, 1] = GameObject.Find ("skeleton224");
		CellArray [0, 2, 1] = GameObject.Find ("skeleton231");
		CellArray [1, 2, 1] = GameObject.Find ("skeleton232");
		CellArray [2, 2, 1] = GameObject.Find ("skeleton233");
		CellArray [3, 2, 1] = GameObject.Find ("skeleton234");
		CellArray [0, 3, 1] = GameObject.Find ("skeleton241");
		CellArray [1, 3, 1] = GameObject.Find ("skeleton242");
		CellArray [2, 3, 1] = GameObject.Find ("skeleton243");
		CellArray [3, 3, 1] = GameObject.Find ("skeleton244");
	}
	
	// Update is called once per frame
	void Update () {
	}
}
