using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hpbar : MonoBehaviour {
	int catLife;
	float rtorigin;
	// Use this for initialization
	void Start () {
		catLife=GameObject.Find ("cat_Idle").GetComponent<Cat> ().CatLife;
		var rt=this.GetComponent<RectTransform>();
		rtorigin = rt.sizeDelta.x;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Life(){
		var rt2=this.GetComponent<RectTransform>();
		Debug.Log (catLife);
		rt2.sizeDelta =new Vector2((float)rt2.sizeDelta.x-rtorigin*(1f / (float)catLife),rt2.sizeDelta.y);
		//rt.sizeDelta =new Vector2((float)rt.sizeDelta.x*0.9f,rt.sizeDelta.y);

	}
}
