using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skelton : MonoBehaviour {
	// Use this for initialization
	public GameObject myChara;
	public int x,y,z;
	public int range;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		ManegeLayer ();
	}
	public void Clicked(){
		if (this.gameObject.layer == 0) {
			GameObject.Find ("Master").GetComponent<Cells> ().ClearColor();
			GetComponent<Renderer> ().material.color =new Color(1f,0.92f,0.016f,0.4f);
			CalcRange ();
		}
		else if (this.gameObject.layer == 8) {

		}

	}

	void ManegeLayer(){
		if (myChara != null) {
			GameObject.Find ("Master").GetComponent<Cells> ().CellArray [x, y, z].layer = 0;
		}

	}

	public void ChangeColor(){
		Debug.Log ("call");
		GetComponent<Renderer> ().material.color =new Color(1f,0.92f,0.016f,0.4f);

	}

	void CalcRange(){
		int range = myChara.GetComponent<Piece> ().range;
		Skelton skeltonTemp;
		GameObject[,,] CellArrayTemp=GameObject.Find ("Master").GetComponent<Cells> ().CellArray;

		CellArrayTemp [x, y, z].GetComponent<Skelton> ().range = range;
		Stack<GameObject> stack = new Stack<GameObject> (){ };
		stack.Push (CellArrayTemp[x,y,z]);
		while(true){
			if (stack.Count==0) {
				break;
			}
			skeltonTemp=stack.Pop ().GetComponent<Skelton>();
			Debug.Log (skeltonTemp);
			CellArrayTemp [skeltonTemp.x, skeltonTemp.y, skeltonTemp.z].GetComponent<Skelton> ().ChangeColor ();
			if (skeltonTemp.range == 0) {
				continue;
			}
			CellArrayTemp [skeltonTemp.x, skeltonTemp.y, skeltonTemp.z].layer = 8;
			CellArrayTemp [skeltonTemp.x, skeltonTemp.y, skeltonTemp.z].GetComponent<Skelton>().range = range;
			CellArrayTemp [skeltonTemp.x, skeltonTemp.y, skeltonTemp.z].GetComponent<Skelton> ().ChangeColor ();

			try{
				if(CellArrayTemp[skeltonTemp.x+1, skeltonTemp.y, skeltonTemp.z].layer!=0){
					stack.Push(CellArrayTemp [skeltonTemp.x+1, skeltonTemp.y, skeltonTemp.z]);
				}
			}catch{
			}try{
				if(CellArrayTemp [skeltonTemp.x-1, skeltonTemp.y, skeltonTemp.z].layer!=0){
					stack.Push(CellArrayTemp [skeltonTemp.x-1, skeltonTemp.y, skeltonTemp.z]);
				}
			}catch{
			}try{
				if(CellArrayTemp [skeltonTemp.x, skeltonTemp.y+1, skeltonTemp.z].layer!=0){
					stack.Push(CellArrayTemp [skeltonTemp.x, skeltonTemp.y+1, skeltonTemp.z]);
				}
			}catch{
			}try{
				if(CellArrayTemp [skeltonTemp.x, skeltonTemp.y-1, skeltonTemp.z].layer!=0){
					stack.Push(CellArrayTemp [skeltonTemp.x, skeltonTemp.y-1, skeltonTemp.z]);
				}
			}catch{
			}try{
				if(CellArrayTemp [skeltonTemp.x, skeltonTemp.y, skeltonTemp.z+1].layer!=0){
					stack.Push(CellArrayTemp [skeltonTemp.x, skeltonTemp.y, skeltonTemp.z+1]);
				}
			}catch{
			}try{
				if(CellArrayTemp [skeltonTemp.x, skeltonTemp.y, skeltonTemp.z-1].layer!=0){
					stack.Push(CellArrayTemp [skeltonTemp.x, skeltonTemp.y, skeltonTemp.z-1]);
				}
			}catch{
			}
			range--;

		}
		GameObject.Find ("Master").GetComponent<Cells> ().CellArray=CellArrayTemp;

	}

}
